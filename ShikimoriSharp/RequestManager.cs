using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Exceptions;


namespace ShikimoriSharp
{
    public class RequestManager
    {
        private readonly TokenBucket _bucketRpm;
        private readonly ILogger _logger;
        private readonly TokenBucket _bucketRps;
        private readonly ClientSettings _settings;
        private readonly Func<AccessToken, Task<AccessToken>> _refresh;
        private AccessToken _token;
        
        
        public RequestManager(ILogger logger, TokenBucket bucketRps, TokenBucket bucketRpm, ClientSettings settings, AccessToken token,  Func<AccessToken, Task<AccessToken>> refresh)
        {
            _logger = logger;
            _bucketRps = bucketRps;
            _bucketRpm = bucketRpm;
            _settings = settings;
            _refresh = refresh;
            _token = token;
        }

        private async Task<HttpResponseMessage> Response(string dest, string method, HttpContent data)
        {
            using var httpClient = new HttpClient();
            await _bucketRpm.TokenRequest();
            await _bucketRps.TokenRequest();
            _logger?.Log(LogLevel.Debug,$"REQUEST {dest}");

            var request = new HttpRequestMessage(new HttpMethod(method), dest);
            request.Headers.TryAddWithoutValidation("User-Agent", _settings.ClientName);
            request.Content = data;
            if (!(_token is null))
                request.Headers.TryAddWithoutValidation("Authorization", $"{_token.TokenType} {_token.Access_Token}");
            var ret = await httpClient.SendAsync(request);
            
            _logger?.Log(LogLevel.Debug, $"RESPONSE {ret.ReasonPhrase}");

            if (ret.StatusCode != HttpStatusCode.BadRequest && ret.StatusCode != HttpStatusCode.Unauthorized)
                return ret;
            if (_refresh is null)
                throw new Exception($"An error occured while token refreshing: {ret.StatusCode}");
            
            _logger?.Log(LogLevel.Warning, "REFRESHING TOKEN");
            _token = await _refresh(_token);
            throw new HttpRequestException($"{ret.StatusCode}");
        }

        public async Task<string> ResponseExecutor(string dest, string method, HttpContent data)
        {
            var policy = Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.TooManyRequests)
                .WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(Math.Pow(2, i)));
            
            var response = await policy.ExecuteAsync(() => Response(dest, method, data));
            
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

        public async Task<TResult> ResponseAsType<TResult>(string dest, string method, HttpContent data)
        {
            var response = await ResponseExecutor(dest, method, data);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TResult>(response));
        }
    }
}