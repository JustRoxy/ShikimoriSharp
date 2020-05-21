using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Tests
{
    [TestFixture]
    public class TokenChange : TestBase
    {
        /// <summary>
        /// Ignore that it can fail
        /// </summary>
        [Test]
        public async Task TokenChangeTest()
        {
            var token = client.Client.Token;
            AccessToken receiveToken = null;
            client.Client.OnTokenChange +=
                accessToken => receiveToken = accessToken;
            var newToken = await client.Client.RefreshAccessToken(token);
            Assert.IsNotNull(receiveToken);
            Assert.AreNotEqual(token.Access_Token, newToken.Access_Token);
            Assert.AreNotEqual(token.RefreshToken, newToken.RefreshToken);
        }
    }
}