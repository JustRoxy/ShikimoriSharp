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
    public class ApiClient
    {
        public delegate void OnAccessToken(AccessToken token);

        public event OnAccessToken OnNewToken;

        private const int RPS = 5;
        private const int RPM = 90;

        /// <summary>
        ///     1.05d is the additional time because of server's inaccuracy
        /// </summary>
        public readonly TokenBucket BucketRpm = new TokenBucket("M", RPM, TimeSpan.FromMinutes(1.05d).TotalMilliseconds);
        public readonly TokenBucket BucketRps = new TokenBucket("S", RPS, TimeSpan.FromSeconds(1).TotalMilliseconds);

        public ApiClient(ILogger logger, ClientSettings settings)
        {
            _logger = logger;
            _settings = settings;
            AuthorizationManager = new AuthorizationManager(settings, RefreshRequest);
        }
        
        public AuthorizationManager AuthorizationManager { get; }

        private readonly ILogger _logger;
        private ClientSettings _settings;
        

        private async Task<AccessToken> RequestTokenRefreshing(AccessToken expiredToken)
        {
            var nToken = await AuthorizationManager.RefreshAccessToken(expiredToken);
            _logger.Log(LogLevel.Information, $"New Token Acquired: {nToken.RefreshToken}");
            OnNewToken?.Invoke(nToken);
            return nToken;
        }

        private Func<AccessToken, RequestManager> Request => x =>
            new RequestManager(_logger, BucketRps, BucketRpm, _settings, x, RequestTokenRefreshing);

        public async Task RequestWithNoResponse(string destination, HttpContent settings, AccessToken token = null, string method = "GET")
        {
            var requester = Request(token);
            await requester.ResponseExecutor(destination, method, settings);
        }

        private async Task<AccessToken> RefreshRequest(string dest, HttpContent content)
        {
            var requester = new RequestManager(_logger, BucketRps, BucketRpm, _settings, null, null);
            return await requester.ResponseAsType<AccessToken>(dest, "POST", content);
        }

        public async Task<TResult> RequestForm<TResult>(string destination, HttpContent settings, AccessToken token = null, string method = "GET")
        {
            var requester = Request(token);
            return await requester.ResponseAsType<TResult>(destination, method, settings);
        }

        public async Task<TResult> RequestForm<TResult>(string destination, AccessToken token = null, string method = "GET")
        {
            return await RequestForm<TResult>(destination, null, token, method);
        }
    }
}