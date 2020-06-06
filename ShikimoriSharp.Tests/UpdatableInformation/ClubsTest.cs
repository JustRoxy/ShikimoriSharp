using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Exceptions;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Tests.UpdatableInformation
{
    [TestFixture]
    public class ClubsTest : TestBase
    {
        [Test]
        public void ClubJoinTest([Values(1)] long id)
        {
            if (IsInScope("clubs"))
                Assert.DoesNotThrowAsync(() => Client.Clubs.Join(id, Token));
            else Assert.ThrowsAsync<ForbiddenException>( () => Client.Clubs.Join(id, Token));
        }

        [Test]
        public void ClubLeaveTest([Values(1)] long id)
        {
            if (IsInScope("clubs"))
                Assert.DoesNotThrowAsync(() =>  Client.Clubs.Leave(id, Token));
            else Assert.ThrowsAsync<ForbiddenException>(() =>  Client.Clubs.Leave(id, Token));
        }

        [Test]
        public async Task GetClubAnimesTest([Values(1)] long id)
        {
            Assert.IsNotNull(await Client.Clubs.GetAnimes(id));
        }

        [Test]
        public async Task GetClubCharactersTest([Values(1)] long id)
        {
            Assert.IsNotNull(await Client.Clubs.GetCharacters(id));
        }

        [Test]
        public async Task GetClubImagesTest([Values(1)] long id)
        {
            Assert.IsNotNull(await Client.Clubs.GetImages(id));
        }

        [Test]
        public async Task GetClubMangasTest([Values(1)] long id)
        {
            Assert.IsNotNull(await Client.Clubs.GetMangas(id));
        }

        [Test]
        public async Task GetClubMembersTest([Values(1)] long id)
        {
            Assert.IsNotNull(await Client.Clubs.GetMembers(id));
        }

        [Test]
        public async Task GetClubsTest([Values("Спортивные аниме и манга (Споконы)")]
            string search)
        {
            Assert.IsNotEmpty(await Client.Clubs.GetClubs());
            var club = await Client.Clubs.GetClubs(new ClubsRequestSettings
            {
                search = search
            });
            Assert.IsNotEmpty(club);
        }
    }
}