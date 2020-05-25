using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Polly;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Exceptions;

namespace ShikimoriSharp
{
    public class ApiClient
    {
        public delegate void NewLog(string log);

        public delegate void OnChange(AccessToken token);

        private const int RPS = 5;
        private const int RPM = 90;

        private const string TokenUrl = "https://shikimori.one/oauth/token";

        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        ///     1.1d is the additional time because of server's inaccuracy
        /// </summary>
        public TokenBucket BucketRpm =
            new TokenBucket("MINUTE", RPM, (int) TimeSpan.FromMinutes(1.1d).TotalMilliseconds);

        public TokenBucket BucketRps = new TokenBucket("SECOND", RPS, (int) TimeSpan.FromSeconds(1).TotalMilliseconds);

        public ApiClient(string clientName, string clientId, string clientSecret, string redirectUrl)
        {
            ClientName = clientName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
        }

        public AccessToken Token { get; private set; }

        public string ClientName { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string RedirectUrl { get; }
        public event OnChange OnTokenChange;

        public event NewLog OnNewLog;

        public async Task Auth(string authCode)
        {
            await GetAccessToken(authCode);
        }

        public void Auth(AccessToken token)
        {
            Token = token;
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

        private async Task<HttpResponseMessage> Request(string dest, string method, HttpContent data,
            bool requestAccess = false)
        {
            var sr = string.Empty;
            await BucketRpm.TokenRequest();
            await BucketRps.TokenRequest();
            sr += $"[{DateTime.Now:HH:mm:ss:ff}] REQUEST {dest}{Environment.NewLine}";
            var request = new HttpRequestMessage(new HttpMethod(method), dest);
            request.Headers.TryAddWithoutValidation("User-Agent", ClientName);
            request.Content = data;
            if (requestAccess)
                request.Headers.TryAddWithoutValidation("Authorization",
                    $"{Token.TokenType} {Token.Access_Token}");
            var ret = await _httpClient.SendAsync(request);
            sr += $"[{DateTime.Now:HH:mm:ss:ff}] RESPONSE {ret.ReasonPhrase}{Environment.NewLine}";
            OnNewLog?.Invoke(sr);
            if (ret.StatusCode != HttpStatusCode.BadRequest && ret.StatusCode != HttpStatusCode.Unauthorized)
                return ret;
            await RefreshAccessToken();
            throw new HttpRequestException("Bad Request Or Unauthorized");
        }

        private async Task<string> MakeStringRequest(string dest, string method, HttpContent data,
            bool requestAccess = false)
        {
            var policy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r =>
                    r.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));

            var response = await policy.ExecuteAsync(async () => await Request(dest, method, data, requestAccess));
            switch (response.StatusCode)
            {
                case HttpStatusCode.UnprocessableEntity:
                    throw new UnprocessableEntityException();
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException();
            }

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Unsuccessful request: {response.StatusCode} | {response.ReasonPhrase}");

            return await response.Content.ReadAsStringAsync();
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

        public async Task<AccessToken> RefreshAccessToken()
        {
            var content = new MultipartFormDataContent
            {
                {new StringContent("refresh_token"), "grant_type"},
                {new StringContent(ClientId), "client_id"},
                {new StringContent(ClientSecret), "client_secret"},
                {new StringContent(Token.RefreshToken), "refresh_token"}
            };

            return await GetAccessTokenRequest(content);
        }

        private async Task<AccessToken> GetAccessTokenRequest(HttpContent stringData)
        {
            var res = await MakeRequest<AccessToken>(TokenUrl, "POST", stringData);
            OnTokenChange?.Invoke(res);
            Token = res;
            return res;
        }

        #endregion
    }
}