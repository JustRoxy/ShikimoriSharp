using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Exceptions;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class UserTest : TestBase
    {
        [Test]
        public async Task GetBansTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetBans(x));
        }

        [Test]
        public async Task GetClubsTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetClubs(x));
        }

        [Test]
        public async Task GetFavouritesTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetFavourites(x));
        }

        [Test]
        public async Task GetFriendsTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetFriends(x));
        }

        [Test]
        public async Task GetHistoryTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetHistory(x));
        }

        /// <summary>
        ///     Can fail when bot have no privileges
        /// </summary>
        [Test]
        public async Task GetMessagesTest([Values(114858)] long x)
        {
            if (IsInScope("messages"))
                Assert.IsNotNull(await Client.Users.GetMessages(x, new MessageRequestSettings("private"), Token));
            else
                Assert.ThrowsAsync<ForbiddenException>(
                    () => Client.Users.GetMessages(x, new MessageRequestSettings("private"), Token));
        }

        [Test]
        public async Task GetUnreadMessagesTest([Values(114858)] long x)
        {
            if (IsInScope("messages"))
                Assert.IsNotNull(await Client.Users.UnreadMessages(x, Token));
            else
                Assert.ThrowsAsync<ForbiddenException>(async () => await Client.Users.UnreadMessages(x, Token));
        }

        [Test]
        public async Task GetUserAnimeRatesTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetUserAnimeRates(x));
        }

        [Test]
        public async Task GetUserMangaRatesTest([Values(114858)] long x)
        {
            Assert.IsNotNull(await Client.Users.GetUserMangaRates(x));
        }

        [Test]
        public async Task GetUsers([Values(114858)] long x, [Values("Algeroplan")] string xName)
        {
            var user = await Client.Users.GetUser(x);
            Assert.AreEqual(xName, user.Nickname);
        }

        [Test]
        public async Task GetUsers([Values("Algeroplan")] string xName)
        {
            var user = await Client.Users.GetUser(xName);
            Assert.AreEqual(xName, user.Nickname);
        }

        [Test]
        public async Task GetUsers([Values(114858)] long x)
        {
            var user = await Client.Users.GetUserInfo(x);
            Assert.AreEqual(x, user.Id);
        }

        [Test]
        public async Task GetUsersTest()
        {
            Assert.IsNotEmpty(await Client.Users.GetUsers());
        }

        [Test]
        public async Task WhoAmI()
        {
            Assert.DoesNotThrowAsync(() => Client.Users.WhoAmI(Token));
            Assert.IsNotNull(await Client.Users.WhoAmI(Token));
        }
    }
}