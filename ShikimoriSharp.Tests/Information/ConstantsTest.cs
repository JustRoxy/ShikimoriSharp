using System.Threading.Tasks;
using NUnit.Framework;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class ConstantsTest : TestBase
    {
        private void AssertProperty(object obj, params string[] props)
        {
            foreach (var prop in props)
                Assert.That(obj, Has.Property(prop).Not.Null);
        }

        [Test]
        public async Task GetAnimeConstantsTest()
        {
            var constant = await Client.Constants.GetAnimeConstants();
            AssertProperty(constant, "Status", "Kind");
        }

        [Test]
        public async Task GetClubConstantsTest()
        {
            var constant = await Client.Constants.GetClubConstants();
            AssertProperty(constant, "CommentPolicy", "JoinPolicy", "ImageUploadPolicy");
        }

        [Test]
        public async Task GetMangaConstantsTest()
        {
            var constant = await Client.Constants.GetMangaConstants();
            AssertProperty(constant, "Status", "Kind");
        }

        [Test]
        public async Task GetSmileysConstantsTest()
        {
            var constant = await Client.Constants.GetSmileysConstants();
            Assert.That(constant, Has.All.Property("Bbcode"));
            Assert.That(constant, Has.All.Property("Path"));
        }

        [Test]
        public async Task GetUserRateConstantsTest()
        {
            var constant = await Client.Constants.GetUserRateConstants();
            AssertProperty(constant, "Status");
        }
    }
}