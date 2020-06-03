using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class PublicUserRate
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("score")] public long Score { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("rewatches")] public long? Rewatches { get; set; }
        [JsonProperty("episodes")] public long? Episodes { get; set; }
        [JsonProperty("volumes")] public long? Volumes { get; set; }
        [JsonProperty("chapters")] public long? Chapters { get; set; }
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("text_html")] public string TextHtml { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    }

    public class UserRate : PublicUserRate
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("target_id")] public long TargetId { get; set; }
        [JsonProperty("target_type")] public string TargetType { get; set; }
    }

    public class AnimeRate : PublicUserRate
    {
        [JsonProperty("user")] public User User { get; set; }
        [JsonProperty("anime")] public Anime Anime { get; set; }
        [JsonProperty("manga")] public Manga Manga { get; set; }
    }
}