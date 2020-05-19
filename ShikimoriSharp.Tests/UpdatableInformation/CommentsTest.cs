using System;
using System.Threading.Tasks;
using NUnit.Framework;
using ShikimoriSharp.Exceptions;
using static ShikimoriSharp.UpdatableInformation.Comments;

namespace ShikimoriSharp.Tests.UpdatableInformation
{
    [TestFixture]
    public class CommentsTest : TestBase
    {
        [Test]
        public async Task GetCommentTest([Values(259192)] long id)
        {
            Assert.NotNull(await client.Comments.GetComment(id));
        }
        [Test]
        public async Task GetCommentTest()
        {
            Assert.NotNull(
                await client.Comments.GetComments(
                    new CommentsRequestSettings(82468, CommentableType.User)));
        }
        
        private async Task<long> SendCommentsTest([Values(2823)] long id)
        {
            var message = new CommentCreateSettings(new CommentCreateContent("Api testing :)", id, "User"));
            if (IsInScope("comments"))
            {
                var resultMessage =
                    await client.Comments.SendComment(message);
                Assert.IsNotNull(resultMessage);
                return resultMessage.Id;
            }

            Assert.ThrowsAsync<ForbiddenException>(async () => await client.Comments.SendComment(message));
            return 0;
        }

        private async Task<long> EditCommentsTest([Values(2823)] long cid, long id)
        {

            var resultMessage =
                await client.Comments.EditComment(id, new CommentEditSettings(new CommentEditContent("Hello")));
            Assert.IsNotNull(resultMessage);
            Assert.AreEqual("Hello", resultMessage.Body);
            return resultMessage.Id;
        }
    }
}