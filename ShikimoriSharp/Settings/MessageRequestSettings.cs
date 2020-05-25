namespace ShikimoriSharp.Settings
{
    public class MessageRequestSettings : BasicSettings
    {
        public string type;

        /// <summary>
        ///     Must be one of: inbox, private, sent, news, notifications
        /// </summary>
        public MessageRequestSettings(string type = "sent")
        {
            this.type = type;
        }
    }
}