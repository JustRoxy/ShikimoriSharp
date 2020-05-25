#nullable enable
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Settings
{
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