using System.Threading.Tasks;
using NUnit.Framework;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class ForumAndGenresTest : TestBase
    {
        [Test]
        public async Task GetForumsTest()
        {
            Assert.IsNotEmpty(await client.Forums.GetForums());
        }
        [Test]
        public async Task GetGenres()
        {
            Assert.IsNotEmpty(await client.Genres.GetGenres());
        }
    }
}