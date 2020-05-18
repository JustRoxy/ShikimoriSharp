using System.Threading.Tasks;
using NUnit.Framework;

namespace ShikimoriSharp.Tests.Information
{
    [TestFixture]
    public class BansCalendarTest : TestBase
    {
        [Test]
        public async Task GetBansTest()
        {
            var bans = await client.Bans.GetBans();
            Assert.IsNotEmpty(bans);
        }

        [Test]
        public async Task GetCalendarTest()
        {
            var calendar = await client.Calendars.GetCalendar();
            Assert.IsNotEmpty(calendar);
        }

    }
}