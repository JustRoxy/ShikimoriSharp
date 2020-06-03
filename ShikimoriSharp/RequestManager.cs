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
    public class RequestManager
    {
        public delegate void NewLog(string log);
        public event NewLog OnNewLog;
        private TokenBucket BucketRpm;
        private TokenBucket BucketRps;
        private ClientSettings _settings;
        private AccessToken _token;
        public Func<AccessToken, Task<AccessToken>> Refresh;
        
        
        public RequestManager(TokenBucket bucketRps, TokenBucket bucketRpm, ClientSettings settings, AccessToken token, Func<AccessToken, Task<AccessToken>> refresh)
        {
            BucketRps = bucketRps;
            BucketRpm = bucketRpm;
            _settings = settings;
            _token = token;
            Refresh = refresh;
        }

        public async Task<HttpResponseMessage> Response(string dest, string method, HttpContent data, bool requestAccess = false)
        {
            using var httpClient = new HttpClient();
            var sr = string.Empty;
            await BucketRpm.TokenRequest();
            await BucketRps.TokenRequest();
            sr += $"[{DateTime.Now:HH:mm:ss:ff}] REQUEST {dest}{Environment.NewLine}";
            var request = new HttpRequestMessage(new HttpMethod(method), dest);
            request.Headers.TryAddWithoutValidation("User-Agent", _settings.ClientName);
            request.Content = data;
            if (requestAccess)
                request.Headers.TryAddWithoutValidation("Authorization",
                    $"{_token.TokenType} {_token.Access_Token}");
            var ret = await httpClient.SendAsync(request);
            sr += $"[{DateTime.Now:HH:mm:ss:ff}] RESPONSE {ret.ReasonPhrase}{Environment.NewLine}";
            if (ret.StatusCode != HttpStatusCode.BadRequest && ret.StatusCode != HttpStatusCode.Unauthorized)
                return ret;
            _token = await Refresh(_token);
            throw new HttpRequestException("Bad Request Or Unauthorized");
        }

        public async Task<string> ResponseExecutor(string dest, string method, HttpContent data, bool requestAccess = false)
        {
            var policy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));

            var response = await policy.ExecuteAsync(() => Response(dest, method, data, requestAccess));
            
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

        public async Task<TResult> ResponseAsType<TResult>(string dest, string method, HttpContent data, bool requestAccess = false)
        {
            var response = await ResponseExecutor(dest, method, data, requestAccess);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResult>(response));
        }
    }
}