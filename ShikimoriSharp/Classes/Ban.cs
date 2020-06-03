using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class Ban
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("comment")] public CommentContent Comment { get; set; }
        [JsonProperty("moderator_id")] public long ModeratorId { get; set; }
        [JsonProperty("reason")] public string Reason { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("duration_minutes")] public long DurationMinutes { get; set; }
        [JsonProperty("user")] public Moderator User { get; set; }
        [JsonProperty("moderator")] public Moderator Moderator { get; set; }
    }
}