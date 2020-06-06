using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class CharactersTest : TestBase
    {
        [Test]
        public async Task GetCharacterByIdTest([Values("Эдогава Конан")] string x)
        {
            var getId = (await Client.Characters.GetCharactersBySearch(x)).First();
            var getChar = await Client.Characters.GetCharacterById(getId.Id);
            Assert.AreEqual(getId.Name, getChar.Name);
        }

        [Test]
        public async Task GetCharactersBySearchBadTest([Values("FJNSAFNASUGFNASIGASSUGA")] string x)
        {
            var badResult = await Client.Characters.GetCharactersBySearch("x");
            Assert.IsEmpty(badResult, "Unfortunately the search should return empty object");
        }

        [Test]
        public async Task GetCharactersBySearchTest([Values("Эдогава Конан")] string x)
        {
            var normalResult = await Client.Characters.GetCharactersBySearch(x);
            Assert.IsNotEmpty(normalResult);
        }
    }
}