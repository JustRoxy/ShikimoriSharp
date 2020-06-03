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
            /*
            var scope = Environment.GetEnvironmentVariable("scope");
            var access = Environment.GetEnvironmentVariable("access_token");
            var refresh = Environment.GetEnvironmentVariable("refresh_token");
            var name = Environment.GetEnvironmentVariable("name");
            var clientId = Environment.GetEnvironmentVariable("client_id");
            var clientSecret = Environment.GetEnvironmentVariable("client_secret");
            userId = Convert.ToInt64(Environment.GetEnvironmentVariable("userId"));
*/
            
            var scope = "user_rates";
            var access = "A7lfe3soDArKqt73GTmqly25tstLpZySyLAy9FrlRUc";
            var refresh = "N28y4B_ySvWV7EiN-ng-0ykOASc2AIeh50wsqKkPFGQ";
            var name = "ShikimoriSharp";
            var clientId = "nsLe5UGPbFIYLeC_q3Wbm65-wOgB6JOLN46Ukmt_RQM";
            var clientSecret = "lCN8nVFM2GDP8hayyLE6dYlzLYVbsE_7pK0OPC93Yk0";
            userId = 124;

            client = ShikimoriClient.Create(new ClientSettings(name, clientId, clientSecret), new AccessToken
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