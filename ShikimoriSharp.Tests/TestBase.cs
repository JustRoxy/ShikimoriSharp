using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Tests
{
    public abstract class TestBase
    {
        protected ShikimoriClient client;
        protected long userId;

        protected TestBase()
        {
            var scope = TestContext.Parameters["scope"];
            var access = TestContext.Parameters["access_token"];
            var refresh = TestContext.Parameters["refresh_token"];
            var name = TestContext.Parameters["name"];
            var clientId = TestContext.Parameters["client_id"];
            var clientSecret = TestContext.Parameters["client_secret"];
            userId = Convert.ToInt64(TestContext.Parameters["userId"]);
            client = ShikimoriClient.Create(name, clientId, clientSecret, new AccessToken
            {
                Access_Token = access,
                RefreshToken = refresh,
                Scope = scope
            });
        }

        protected bool IsInScope(string scope)
        {
            return client.Client.Token.Scope.Split(" ").Any(it => it == scope);
        }
    }
}