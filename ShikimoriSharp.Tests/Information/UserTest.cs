using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Exceptions;
using static ShikimoriSharp.Information.Users;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class UserTest : TestBase
    {
        [Test]
        public async Task GetUsersTest()
        {
            Assert.IsNotEmpty(await client.Users.GetUsers());
        }
        
        [Test]
        public async Task GetUsers([Values(114858)] long x, [Values("Algeroplan")] string xName)
        {
            var user = await client.Users.GetUser(x);
            Assert.AreEqual(xName, user.Nickname);
        }
        
        [Test]
        public async Task GetUsers([Values("Algeroplan")] string xName)
        {
            var user = await client.Users.GetUser(xName);
            Assert.AreEqual(xName, user.Nickname);
        }
        
        [Test]
        public async Task GetUsers([Values(114858)] long x)
        {
            var user = await client.Users.GetUserInfo(x);
            Assert.AreEqual(x, user.Id);
        }

        [Test]
        public async Task WhoAmI()
        {
            Assert.DoesNotThrowAsync(async () => await client.Users.WhoAmI());
            Assert.IsNotNull(await client.Users.WhoAmI());
        }

        [Test]
        public async Task GetFriendsTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetFriends(x));
        }
        
        [Test]
        public async Task GetClubsTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetClubs(x));
        }
        
        [Test]
        public async Task GetUserAnimeRatesTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetUserAnimeRates(x));
        }
        
        [Test]
        public async Task GetUserMangaRatesTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetUserMangaRates(x));
        }
        
        [Test]
        public async Task GetFavouritesTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetFavourites(x));
        }
        
        /// <summary>
        /// Can fail when bot have no privileges
        /// </summary>
        [Test]
        public async Task GetMessagesTest([Values(114858)] long x)
        {
            if (client.Client.Token.Scope.Contains("messages"))
                Assert.IsNotNull(await client.Users.GetMessages(x, new MessageRequestSettings("private")));
            else
                Assert.ThrowsAsync<ForbiddenException>(
                    async () => await client.Users.GetMessages(x, new MessageRequestSettings("private")));
        }

        [Test]
        public async Task GetUnreadMessagesTest([Values(114858)] long x)
        {
            if (IsInScope("messages"))
                Assert.IsNotNull(await client.Users.UnreadMessages(x));
            else
                Assert.ThrowsAsync<ForbiddenException>(async () => await client.Users.UnreadMessages(x));
        }

        [Test]
        public async Task GetHistoryTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetHistory(x));
        }
        
        [Test]
        public async Task GetBansTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await client.Users.GetBans(x));
        }
    }
}