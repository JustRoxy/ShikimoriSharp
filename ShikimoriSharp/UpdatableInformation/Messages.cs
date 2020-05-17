using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Messages : ApiBase
    {
        public enum MessageType
        {
            news,
            notification
        }

        public Messages(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Users.Message> GetMessages(int id)
        {
            return await Request<Users.Message>($"messages/{id}", true);
        }

        public async Task<Users.Message> SendMessage(MessageToSend message)
        {
            return await SendJson<Users.Message>("messages", message, true);
        }

        public async Task<Users.Message> EditMessage(int id, MessageToEdit message)
        {
            return await SendJson<Users.Message>($"messages/{id}", message, true);
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

        public class AllSettings
        {
            public bool? frontend;
            public MessageType? type;
        }

        public class MarkReadSettings
        {
            public string? ids;
        }

        #region Edit Message

        public class MessageToEditContent
        {
            public string body;

            public MessageToEditContent(string body)
            {
                this.body = body;
            }
        }

        public class MessageToEdit
        {
            public bool? frontend;

            [JsonProperty("message")] public MessageToEditContent message;

            public MessageToEdit(MessageToEditContent message)
            {
                this.message = message;
            }
        }

        #endregion

        #region Send Message

        public class MessageContent
        {
            public string body;
            public int from_id;
            public string kind;
            public int to_id;

            public MessageContent(string body, int fromId, string kind, int toId)
            {
                this.body = body;
                from_id = fromId;
                this.kind = kind;
                to_id = toId;
            }
        }

        public class MessageToSend
        {
            public bool? frontend;

            [JsonProperty("message")] public MessageContent message;

            public MessageToSend(MessageContent content)
            {
                message = content;
            }
        }

        #endregion
    }
}