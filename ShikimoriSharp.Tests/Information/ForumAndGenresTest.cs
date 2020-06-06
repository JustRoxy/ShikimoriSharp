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
            Assert.IsNotEmpty(await Client.Forums.GetForums());
        }

        [Test]
        public async Task GetGenres()
        {
            Assert.IsNotEmpty(await Client.Genres.GetGenres());
        }
    }
}