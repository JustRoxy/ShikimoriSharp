using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class StatsAndStudiosTest : TestBase
    {
        [Test]
        public async Task GetActiveUsersTest()
        {
            Assert.IsNotEmpty(await client.Stats.GetActiveUsers());
        }

        [Test]
        public async Task GetStudios()
        {
            var studio = await client.Studios.GetStudios();
            var studiosn = studio.Where(it => !(it.Image is null));
            Assert.IsNotEmpty(studio);
        }
    }
}