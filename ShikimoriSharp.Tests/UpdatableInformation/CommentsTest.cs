using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Enums;
using ShikimoriSharp.Exceptions;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Tests.UpdatableInformation
{
    [TestFixture]
    public class CommentsTest : TestBase
    {
        [Test]
        public async Task GetCommentTest([Values(259192)] long id)
        {
            Assert.NotNull(await Client.Comments.GetComment(id, Token));
        }

        [Test]
        public async Task GetCommentTest()
        {
            Assert.NotNull(
                await Client.Comments.GetComments(
                    new CommentsRequestSettings(82468, CommentableType.User), Token));
        }
    }
}