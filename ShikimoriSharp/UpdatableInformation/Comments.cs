using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Comments : ApiBase
    {
        public Comments(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Comment> GetComment(long id)
        {
            return await Request<Comment>($"comments/{id}", true);
        }

        public async Task<Comment[]> GetComments(CommentsRequestSettings settings)
        {
            return await Request<Comment[], CommentsRequestSettings>("comments", settings, true);
        }

        public async Task<Comment> SendComment(CommentCreateSettings settings)
        {
            return await SendJson<Comment>("comments", settings, true);
        }

        public async Task<Comment> EditComment(long id, CommentEditSettings newMessage)
        {
            return await SendJson<Comment>($"comments/{id}", newMessage, true, "PUT");
        }

        public async Task DeleteComment(long id)
        {
            await NoResponseRequest($"comment/{id}", true, "DELETE");
        }
    }
}