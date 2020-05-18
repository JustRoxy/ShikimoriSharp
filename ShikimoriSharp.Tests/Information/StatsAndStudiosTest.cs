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
            Assert.IsNotEmpty(await client.Studios.GetStudios());
        }
    }
}