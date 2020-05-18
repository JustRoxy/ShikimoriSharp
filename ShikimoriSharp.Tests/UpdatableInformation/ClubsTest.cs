using System.Threading.Tasks;
using NUnit.Framework;
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
    }
}