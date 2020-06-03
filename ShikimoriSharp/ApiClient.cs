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
        public delegate void OnAccessToken(AccessToken token);

        public event OnAccessToken OnNewToken;

        private const int RPS = 5;
        private const int RPM = 90;

        /// <summary>
        ///     1.05d is the additional time because of server's inaccuracy
        /// </summary>
        public readonly TokenBucket BucketRpm = new TokenBucket("M", RPM, TimeSpan.FromMinutes(1.05d).TotalMilliseconds);
        public readonly TokenBucket BucketRps = new TokenBucket("S", RPS, TimeSpan.FromSeconds(1).TotalMilliseconds);

        public ApiClient(ClientSettings settings)
        {
            _settings = settings;
            _manager = new AuthorizationManager(settings,
                (s, s1, arg3) => RequestForm<AccessToken>(s, arg3, method: s1));
        }
        
        private AuthorizationManager _manager;
        public AccessToken Token { get; private set; }

        private ClientSettings _settings;

        public async Task Auth(string authCode)
        {
            Token = await _manager.GetAccessToken(authCode);
        }

        public void Auth(AccessToken token)
        {
            Token = token;
        }

        private async Task<AccessToken> TokenRequestRefreshing(AccessToken expiredToken)
        {
            var nToken = await _manager.RefreshAccessToken(expiredToken);
            OnNewToken?.Invoke(nToken);
            return nToken;
        }
        
        public async Task RequestWithNoResponse(string destination, HttpContent settings, bool requestAccess = false, string method = "GET")
        {
            var requester = new RequestManager(BucketRps, BucketRpm, _settings, Token, TokenRequestRefreshing);
            await requester.ResponseExecutor(destination, method, settings, requestAccess);
        }

        public async Task<TResult> RequestForm<TResult>(string destination, HttpContent settings, bool requestAccess = false, string method = "GET")
        {
            var requester = new RequestManager(BucketRps, BucketRpm, _settings, Token, TokenRequestRefreshing);
            return await requester.ResponseAsType<TResult>(destination, method, settings, requestAccess);
        }

        public async Task<TResult> RequestForm<TResult>(string destination, bool requestAccess = false, string method = "GET")
        {
            return await RequestForm<TResult>(destination, null, requestAccess, method);
        }
    }
}