using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Exceptions;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class AchievementsTest : TestBase
    {
        [Test]
        public async Task HaveValueTest()
        {
            var value = await client.Achievements.GetAchievements(
                new AchievementsSettings(userId));
            Assert.That(value.Length, Is.GreaterThan(15));
        }

        [Test]
        public void IsFailingTest()
        {
            Assert.ThrowsAsync<UnprocessableEntityException>(async () =>
                await client.Achievements.GetAchievements(new AchievementsSettings(-1)));
        }
    }
}