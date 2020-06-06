using System;
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Classes
{
    public class CommentContent
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("commentable_id")] public long CommentableId { get; set; }
        [JsonProperty("commentable_type")] public CommentableType CommentableType { get; set; }
        [JsonProperty("body")] public string Body { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
        [JsonProperty("is_summary")] public bool IsSummary { get; set; }
        [JsonProperty("is_offtopic")] public bool IsOfftopic { get; set; }
    }

    public class Comment : CommentContent
    {
        [JsonProperty("html_body")] public string HtmlBody { get; set; }
        [JsonProperty("can_be_edited")] public bool CanBeEdited { get; set; }
        [JsonProperty("user")] public User User { get; set; }
    }
}