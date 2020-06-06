using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Enums;
using ShikimoriSharp.Exceptions;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class AnimesTest : TestBase
    {
        [Test]
        public void GetAnimeByIdFailTest()
        {
            Assert.ThrowsAsync<Exception>(
                async () => await Client.Animes.GetAnime(-1));
        }

        [Test]
        public async Task GetAnimeByIdTest()
        {
            var anime = (await Client.Animes.GetAnime(new AnimeRequestSettings
            {
                search = "Detective Conan"
            })).First();
            var idAnime = await Client.Animes.GetAnime(anime.Id);
            Assert.AreEqual(anime.Name, idAnime.Name);
            Assert.AreEqual(anime.Id, idAnime.Id);
        }

        [Test]
        public async Task GetAnimeExternalLinksTest([Values(50)] long x)
        {
            var links = await Client.Animes.GetExternalLinks(x);
            Assert.IsNotEmpty(links);
        }

        [Test]
        public void GetAnimeFailTest()
        {
            Assert.ThrowsAsync<UnprocessableEntityException>(() => Client.Animes.GetAnime(
                new AnimeRequestSettings
                {
                    limit = 100000,
                    page = 2000000
                }));
        }

        [Test]
        public void GetAnimeFranchiseTest([Values(50)] long x)
        {
            Assert.DoesNotThrowAsync(() => Client.Animes.GetFranchise(x));
        }

        [Test]
        public async Task GetAnimeMyListTest()
        {
            var anime = await Client.Animes.GetAnime(new AnimeRequestSettings
            {
                limit = 5,
                mylist = MyList.completed
            });
            var ids = anime.Select(it => it.Id)
                .Select(async it => (await Client.UserRates.GetUsersRates(new UserRatesSettings
                {
                    user_id = UserId,
                    target_id = it,
                    target_type = TargetType.Anime
                })).First()).Select(it => it.Result);
            Assert.That(ids.Select(it => it.Status), Is.All.EqualTo("completed"));
        }

        [Test]
        public async Task GetAnimeRelatedTest([Values(50)] long x)
        {
            var similar = await Client.Animes.GetRelated(x);
            Assert.IsTrue(similar.All(it => !(it.Anime is null && it.Manga is null)));
        }

        [Test]
        public async Task GetAnimeRolesTest([Values(50)] long x)
        {
            var roles = await Client.Animes.GetRoles(x);
            Assert.IsNotEmpty(roles);
        }

        [Test]
        public async Task GetAnimeScreenshotsTest([Values(50)] long x)
        {
            var screens = await Client.Animes.GetScreenshots(x);
            Assert.IsNotEmpty(screens);
            Assert.That(screens, Has.All.Property("Original").Not.Null);
            Assert.That(screens, Has.All.Property("Preview").Not.Null);
        }

        [Test]
        public async Task GetAnimeSettingsTest()
        {
            var result = await Client.Animes.GetAnime(new AnimeRequestSettings
            {
                limit = 10,
                search = "Naruto"
            });
            Assert.That(result.Length, Is.EqualTo(10));
            Assert.True(result.First().Name.Contains("Naruto"));
        }

        [Test]
        public async Task GetAnimeSimilarTest([Values(50)] long x)
        {
            var similar = await Client.Animes.GetSimilar(x);
            Assert.IsNotEmpty(similar);
            Assert.That(similar, Has.All.Property("Id").Not.Null);
        }

        [Test]
        public async Task GetAnimeTest()
        {
            var result = await Client.Animes.GetAnime();
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void GetAnimeTopicsTest([Values(50)] long x)
        {
            Assert.DoesNotThrowAsync(() => Client.Animes.GetTopics(x));
        }
    }
}