using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Exceptions;

namespace ShikimoriSharp
{
    public class ApiClient
    {
        public delegate void OnChange(AccessToken token);

        private const int RPS = 5;
        private const int RPM = 90;

        private const string TokenUrl = "https://shikimori.one/oauth/token";
        private AccessToken _currentToken;
        public AccessToken Token => _currentToken; 
        public TokenBucket BucketRpm = new TokenBucket("MINUTE", RPM, 60 * 1200);
        public TokenBucket BucketRps = new TokenBucket("SECUND", RPS, 1 * 1500);

        public ApiClient(string clientName, string clientId, string clientSecret, string redirectUrl)
        {
            ClientName = clientName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
        }

        public string ClientName { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string RedirectUrl { get; }
        public event OnChange OnTokenChange;

        public async Task Auth(string authCode)
        {
            await GetAccessToken(authCode);
        }

        public void Auth(AccessToken token)
        {
            _currentToken = token;
        }

        public async Task NoResponseRequest(string destination, HttpContent settings, bool requestAccess = false,
            string method = "GET")
        {
            await MakeStringRequest(destination, method, settings,
                requestAccess);
        }

        public async Task<TResult> RequestApi<TResult>(string destination, HttpContent settings,
            bool requestAccess = false, string method = "GET")
        {
            return await MakeRequest<TResult>(destination, method, settings,
                requestAccess);
        }

        public async Task<TResult> RequestApi<TResult>(string destination, bool requestAccess = false,
            string method = "GET")
        {
            return await RequestApi<TResult>(destination, null, requestAccess);
        }

        private async Task<string> MakeStringRequest(string dest, string method, HttpContent data,
            bool requestAccess = false)
        {
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage(new HttpMethod(method), dest);
            request.Headers.TryAddWithoutValidation("User-Agent", ClientName);
            if (requestAccess)
                request.Headers.TryAddWithoutValidation("Authorization",
                    $"{_currentToken.TokenType} {_currentToken.Access_Token}");
            request.Content = data;
            while (true)
            {
                await Task.WhenAll(BucketRps.TokenRequest(), BucketRpm.TokenRequest());
                var response = await httpClient.SendAsync(request);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.TooManyRequests:
                    {
                        await Task.Delay(1000);
                        break;
                    }
                    case HttpStatusCode.UnprocessableEntity:
                        throw new UnprocessableEntityException();
                    case HttpStatusCode.Forbidden:
                        throw new ForbiddenException();
                    case HttpStatusCode.Unauthorized:
                        await RefreshAccessToken(_currentToken);
                        break;
                    default:
                    {
                        if (response.IsSuccessStatusCode)
                            return await response.Content.ReadAsStringAsync();
                        throw new Exception($"Unsuccessful request: {response.StatusCode} | {response.ReasonPhrase}");
                    }
                }
            }
        }

        private async Task<TResult> MakeRequest<TResult>(string dest, string method, HttpContent data,
            bool requestAccess = false)
        {
            var response = await MakeStringRequest(dest, method, data, requestAccess);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResult>(response));
        }


        #region Authorization

        public async Task<AccessToken> GetAccessToken(string authCode)
        {
            var content = new MultipartFormDataContent
            {
                {new StringContent("authorization_code"), "grant_type"},
                {new StringContent(ClientId), "client_id"},
                {new StringContent(ClientSecret), "client_secret"},
                {new StringContent(authCode), "code"},
                {new StringContent(RedirectUrl), "redirect_uri"}
            };

            return await GetAccessTokenRequest(content);
        }

        public async Task<AccessToken> RefreshAccessToken(AccessToken token)
        {
            var content = new MultipartFormDataContent
            {
                {new StringContent("refresh_token"), "grant_type"},
                {new StringContent(ClientId), "client_id"},
                {new StringContent(ClientSecret), "client_secret"},
                {new StringContent(token.RefreshToken), "refresh_token"}
            };

            return await GetAccessTokenRequest(content);
        }

        private async Task<AccessToken> GetAccessTokenRequest(HttpContent stringData)
        {
            var res = await MakeRequest<AccessToken>(TokenUrl, "POST", stringData);
            if (res.RefreshToken != _currentToken.RefreshToken || res.Access_Token != _currentToken.Access_Token)
                OnTokenChange?.Invoke(res);
            _currentToken = res;
            return res;
        }

        #endregion
    }
}