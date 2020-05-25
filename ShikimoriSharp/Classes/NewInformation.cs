using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class NewInformation
    {
        [JsonProperty("messages")] public long Messages { get; set; }
        [JsonProperty("news")] public long News { get; set; }
        [JsonProperty("notifications")] public long Notifications { get; set; }
    }
}