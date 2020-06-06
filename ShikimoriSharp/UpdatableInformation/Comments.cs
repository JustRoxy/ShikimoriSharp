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

        public async Task<Comment> GetComment(long id, AccessToken personalInformation)
        {
            return await Request<Comment>($"comments/{id}", personalInformation);
        }

        public async Task<Comment[]> GetComments(CommentsRequestSettings settings, AccessToken personalInformation)
        {
            return await Request<Comment[], CommentsRequestSettings>("comments", settings, personalInformation);
        }

        public async Task<Comment> SendComment(CommentCreateSettings settings, AccessToken personalInformation)
        {
            return await SendJson<Comment>("comments", settings, personalInformation);
        }

        public async Task<Comment> EditComment(long id, CommentEditSettings newMessage, AccessToken personalInformation)
        {
            return await SendJson<Comment>($"comments/{id}", newMessage, personalInformation, "PUT");
        }

        public async Task DeleteComment(long id, AccessToken personalInformation)
        {
            await NoResponseRequest($"comment/{id}", true, personalInformation, "DELETE");
        }
    }
}