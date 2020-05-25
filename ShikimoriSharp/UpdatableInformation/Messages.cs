using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Messages : ApiBase
    {
        public Messages(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Message> GetMessages(int id)
        {
            return await Request<Message>($"messages/{id}", true);
        }

        public async Task<Message> SendMessage(MessageToSend message)
        {
            return await SendJson<Message>("messages", message, true);
        }

        public async Task<Message> EditMessage(int id, MessageToEdit message)
        {
            return await SendJson<Message>($"messages/{id}", message, true);
        }

        public async Task DeleteMessage(int id)
        {
            await NoResponseRequest($"messages/{id}", method: "DELETE");
        }

        public async Task MarkRead(MarkReadSettings settings = null)
        {
            await NoResponseRequest("messages/mark_read", settings);
        }

        public async Task ReadAll(AllSettings settings = null)
        {
            await NoResponseRequest("messages/read_all", settings);
        }

        public async Task DeleteAll(AllSettings settings = null)
        {
            await NoResponseRequest("messages/delete_all", settings);
        }
    }
}