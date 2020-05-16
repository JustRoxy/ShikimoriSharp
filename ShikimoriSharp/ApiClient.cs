using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikimoriSharp
{
    public class ApiClient
    {
        public ApiClient(string clientName, string clientId, string clientSecret, string redirectUrl)
        {
            ClientName = clientName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
        }
        public class AccessToken
        {
            [JsonProperty("access_token")]
            public string Access_Token { get; set; }
            
            [JsonProperty("token_type")]
            public string TokenType { get; set; }
            
            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }
            
            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }
            
            [JsonProperty("scope")]
            public string Scope { get; set; }
            
            [JsonProperty("created_at")] 
            public long CreatedAt { get; set; }

        }

        private AccessToken _currentToken;
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
        public async Task<TResult> RequestApi<TResult>(string destination, HttpContent settings, bool requestAccess = false)
        {
            return await MakeRequest<TResult>(destination, "GET", settings, new Exception("Api request failed"),
                requestAccess);

        }
        public async Task<TResult> RequestApi<TResult>(string destination, bool requestAccess = false)
        {
            return await RequestApi<TResult>(destination, null, requestAccess);
        }

        private async Task<TResult> MakeRequest<TResult>(string dest, string method, HttpContent data, Exception error, bool requestAccess = false)
        {
            string result;
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage(new HttpMethod(method), dest);
            request.Headers.TryAddWithoutValidation("User-Agent", ClientName);
            if (requestAccess)
            {
                request.Headers.TryAddWithoutValidation("Authorization",
                    $"{_currentToken.TokenType} {_currentToken.Access_Token}");
            }
            request.Content = data;
            while (true)
            {
                var response = await httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                    await RefreshAccessToken(_currentToken);
                else if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                    return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResult>(result));
                } 
                else
                    throw new Exception($"Unsuccessful request: {response.StatusCode}, {response.Content}");
            }
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
            var res = await MakeRequest<AccessToken>("https://shikimori.one/oauth/token", "POST", stringData,
                new Exception("Get Access Token Failed"));
            _currentToken = res;
            return res;
        }

        #endregion
        
        

    }
}