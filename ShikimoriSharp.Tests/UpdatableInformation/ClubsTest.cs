using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Exceptions;
using ShikimoriSharp.UpdatableInformation;

namespace ShikimoriSharp.Tests.UpdatableInformation
{
    [TestFixture]
    public class ClubsTest : TestBase
    {
        [Test]
        public async Task GetClubsTest([Values("Разработка сайта")] string search)
        {
            Assert.IsNotEmpty(await client.Clubs.GetClubs());
            var club = await client.Clubs.GetClubs(new Clubs.ClubsRequestSettings
            {
                search = search
            });
            Assert.IsNotEmpty(club);
        }
        [Test]
        public async Task GetClubAnimesTest([Values(1)] long id)
        {
            Assert.IsNotNull(await client.Clubs.GetAnimes(id));
        }
        
        [Test]
        public async Task GetClubMangasTest([Values(1)] long id)
        {
            Assert.IsNotNull(await client.Clubs.GetMangas(id));
        }
        
        [Test]
        public async Task GetClubCharactersTest([Values(1)] long id)
        {
            Assert.IsNotNull(await client.Clubs.GetCharacters(id));
        }
        
        [Test]
        public async Task GetClubMembersTest([Values(1)] long id)
        {
            Assert.IsNotNull(await client.Clubs.GetMembers(id));
        }
        
        [Test]
        public async Task GetClubImagesTest([Values(1)] long id)
        {
            Assert.IsNotNull(await client.Clubs.GetImages(id));
        }

        [Test]
        public async Task ClubJoinTest([Values(1)] long id)
        {
            if (IsInScope("clubs"))
                Assert.DoesNotThrowAsync(async () => await client.Clubs.Join(id));
            else Assert.ThrowsAsync<ForbiddenException>(async () => await client.Clubs.Join(id));
        }
        
        [Test]
        public async Task ClubLeaveTest([Values(1)] long id)
        {
            if (IsInScope("clubs"))
                Assert.DoesNotThrowAsync(async () => await client.Clubs.Leave(id));
            else Assert.ThrowsAsync<ForbiddenException>(async () => await client.Clubs.Leave(id));
        }
        
    }
}