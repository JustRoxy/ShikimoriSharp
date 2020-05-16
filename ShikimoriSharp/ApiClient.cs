using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikimoriSharp
{
    public class ApiClient
    {
        private const string TokenUrl = "https://shikimori.one/oauth/token";
        private AccessToken _currentToken;
        
        public delegate void OnChange(AccessToken token);
        public event OnChange OnTokenChange;

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

        public async Task Auth(string authCode)
        {
            await GetAccessToken(authCode);
        }

        public void Auth(AccessToken token)
        {
            _currentToken = token;
        }

        public async Task NoResponseRequest(string destination, HttpContent settings, bool requestAccess = false, string method = "GET")
        {
            await MakeStringRequest(destination, method, settings, new Exception("Shit happened"),
                requestAccess);
        }

        public async Task<TResult> RequestApi<TResult>(string destination, HttpContent settings,
            bool requestAccess = false, string method = "GET")
        {
            return await MakeRequest<TResult>(destination, method, settings, new Exception("Api request failed"),
                requestAccess);
        }

        public async Task<TResult> RequestApi<TResult>(string destination, bool requestAccess = false, string method = "GET")
        {
            return await RequestApi<TResult>(destination, null, requestAccess);
        }

        private async Task<string> MakeStringRequest(string dest, string method, HttpContent data, Exception error,
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
                var response = await httpClient.SendAsync(request);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.UnprocessableEntity:
                        throw new Exception(
                            $"{response.ReasonPhrase}, something is empty. It's probably because of already deleted dialog, or the club's name is empty");
                    case HttpStatusCode.Forbidden:
                        throw new Exception(
                            "You were trying to access a forbidden information. Check your bot's privileges" +
                            $"{Environment.NewLine}Unsuccessful request: {response.StatusCode} | {response.ReasonPhrase}");
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

        private async Task<TResult> MakeRequest<TResult>(string dest, string method, HttpContent data, Exception error,
            bool requestAccess = false)
        {
            var response = await MakeStringRequest(dest, method, data, error, requestAccess);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResult>(response));
        }

        public class AccessToken
        {
            [JsonProperty("access_token")] public string Access_Token { get; set; }

            [JsonProperty("token_type")] public string TokenType { get; set; }

            [JsonProperty("expires_in")] public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

            [JsonProperty("scope")] public string Scope { get; set; }

            [JsonProperty("created_at")] public long CreatedAt { get; set; }
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
            var res = await MakeRequest<AccessToken>(TokenUrl, "POST", stringData,
                new Exception("Get Access Token Failed"));
            if (res.RefreshToken != _currentToken.RefreshToken || res.Access_Token != _currentToken.Access_Token)
                OnTokenChange?.Invoke(res);
            _currentToken = res;
            return res;
        }

        #endregion
    }
}