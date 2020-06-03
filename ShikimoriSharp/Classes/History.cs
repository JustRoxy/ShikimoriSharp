using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class History
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("target")] public HistoryTarget Target { get; set; }
    }

    public class HistoryTarget : Anime
    {
        [JsonProperty("volumes")] public long Volumes { get; set; }
        [JsonProperty("chapters")] public long Chapters { get; set; }
    }
}