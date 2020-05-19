using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Bases;
using static ShikimoriSharp.Information.Mangas;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class MangasTest : TestBase
    {
        [Test]
        public async Task GetMangaByIdTest([Values(418)] long x)
        {
            var manga = (await client.Mangas.GetManga(new MangaRequestSettings
            {
                search = "Mushishi"
            })).First();
            var id = manga.Id;

            var actual = await client.Mangas.GetManga(id);
            Assert.AreEqual(actual.Name, manga.Name);
            Assert.AreEqual(actual.Id, manga.Id);
        }

        [Test]
        public async Task GetMangaExternalLinksTest([Values(418)] long x)
        {
            Assert.IsNotEmpty(await client.Mangas.GetExternalLinks(x));
        }

        [Test]
        public async Task GetMangaFranchiseTest([Values(418)] long x)
        {
            Assert.IsNotNull(await client.Mangas.GetFranchise(x));
        }

        [Test]
        public async Task GetMangaRelatedTest([Values(418)] long x)
        {
            var related = await client.Mangas.GetRelated(x);
            Assert.IsNotEmpty(related);
        }

        [Test]
        public async Task GetMangaRolesTest([Values(418)] long x)
        {
            var roles = await client.Mangas.GetRoles(x);
            Assert.IsNotEmpty(roles);
        }

        [Test]
        public async Task GetMangaSettingsTest([Values("Mushishi")] string search,
            [Values("Мастер Муси")] string expect)
        {
            var mangas = (await client.Mangas.GetManga(new MangaRequestSettings
            {
                limit = 1,
                search = search
            })).First();
            Assert.That(mangas.Russian.ToString()?.ToLower(), Is.EqualTo(expect.ToLower()));
        }

        [Test]
        public async Task GetMangaSettingsTopicsTest([Values(418)] long x)
        {
            Assert.AreEqual(2, (await client.Mangas.GetTopics(x, new BasicSettings
            {
                limit = 2
            })).Length);
        }

        [Test]
        public async Task GetMangaTest()
        {
            Assert.IsNotEmpty(await client.Mangas.GetManga());
        }

        [Test]
        public async Task GetMangaTopicsTest([Values(418)] long x)
        {
            Assert.IsNotNull(await client.Mangas.GetTopics(x));
        }
    }
}