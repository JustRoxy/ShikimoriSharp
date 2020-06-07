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

        public async Task<Message> GetMessages(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            return await Request<Message>($"messages/{id}", personalInformation);
        }

        public async Task<Message> SendMessage(MessageToSend message, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            return await SendJson<Message>("messages", message, personalInformation);
        }

        public async Task<Message> EditMessage(int id, MessageToEdit message, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            return await SendJson<Message>($"messages/{id}", message, personalInformation);
        }

        public async Task DeleteMessage(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"messages"});
            await NoResponseRequest($"messages/{id}", personalInformation, method: "DELETE");
        }

        public async Task MarkRead(AccessToken personalInformation, MarkReadSettings settings = null)
        {
            Requires(personalInformation, new[] {"messages"});
            await NoResponseRequest("messages/mark_read", settings, personalInformation);
        }

        public async Task ReadAll(AccessToken personalInformation, AllSettings settings = null)
        {
            Requires(personalInformation, new[] {"messages"});
            await NoResponseRequest("messages/read_all", settings, personalInformation);
        }

        public async Task DeleteAll(AccessToken personalInformation, AllSettings settings = null)
        {
            Requires(personalInformation, new[] {"messages"});
            await NoResponseRequest("messages/delete_all", settings, personalInformation);
        }
    }
}