using System;
using System.Linq;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Tests
{
    public abstract class TestBase
    {
        protected ShikimoriClient client;
        protected long userId;

        protected TestBase()
        {
            var scope = Environment.GetEnvironmentVariable("scope");
            var access = Environment.GetEnvironmentVariable("access_token");
            var refresh = Environment.GetEnvironmentVariable("refresh_token");
            var name = Environment.GetEnvironmentVariable("name");
            var clientId = Environment.GetEnvironmentVariable("client_id");
            var clientSecret = Environment.GetEnvironmentVariable("client_secret");
            userId = Convert.ToInt64(Environment.GetEnvironmentVariable("userId"));
            client = ShikimoriClient.Create(name, clientId, clientSecret, new AccessToken
            {
                Access_Token = access,
                RefreshToken = refresh,
                Scope = scope
            });
        }

        protected bool IsInScope(string scope)
        {
            return !(client.Client.Token.Scope is null) && client.Client.Token.Scope.Split(" ").Any(it => it == scope);
        }
    }
}