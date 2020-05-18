using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class CharactersTest : TestBase
    {
        [Test]
        public async Task GetCharactersBySearchTest([Values("Эдогава Конан")] string x)
        {
            var normalResult = await client.Characters.GetCharactersBySearch(x);
            Assert.IsNotEmpty(normalResult);
        }

        [Test]
        public async Task GetCharactersBySearchBadTest([Values("FJNSAFNASUGFNASIGASSUGA")] string x)
        {
            var badResult = await client.Characters.GetCharactersBySearch("FJNSAFNASUGFNASIGASUGNAUOGASUOGASUGA");
            Assert.IsEmpty(badResult, "Unfortunately the search should return empty object");
        }

        [Test]
        public async Task GetCharacterByIdTest([Values("Эдогава Конан")] string x)
        {
            var getId = (await client.Characters.GetCharactersBySearch(x)).First();
            var getChar = await client.Characters.GetCharacterById(getId.Id);
            Assert.AreEqual(getId.Name, getChar.Name);
        }
    }
}