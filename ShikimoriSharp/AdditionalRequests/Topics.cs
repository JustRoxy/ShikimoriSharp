using System;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.AdditionalRequests
{
    public partial class Topic
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("topic_title")]
        public string TopicTitle { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("html_body")]
        public string HtmlBody { get; set; }

        [JsonProperty("html_footer")]
        public string HtmlFooter { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("comments_count")]
        public long CommentsCount { get; set; }

        [JsonProperty("forum")]
        public Forum Forum { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("linked_id")]
        public long LinkedId { get; set; }

        [JsonProperty("linked_type")]
        public string LinkedType { get; set; }

        [JsonProperty("linked")]
        public Linked Linked { get; set; }

        [JsonProperty("viewed")]
        public bool Viewed { get; set; }

        [JsonProperty("last_comment_viewed")]
        public object LastCommentViewed { get; set; }

        [JsonProperty("event")]
        public object Event { get; set; }

        [JsonProperty("episode")]
        public object Episode { get; set; }
    }

    public partial class Forum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Linked
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("russian")]
        public string Russian { get; set; }

        [JsonProperty("image")]
        public LinkedImage Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("volumes")]
        public long Volumes { get; set; }

        [JsonProperty("chapters")]
        public long Chapters { get; set; }

        [JsonProperty("aired_on")]
        public object AiredOn { get; set; }

        [JsonProperty("released_on")]
        public object ReleasedOn { get; set; }
    }

    public partial class LinkedImage
    {
        [JsonProperty("original")]
        public string Original { get; set; }

        [JsonProperty("preview")]
        public string Preview { get; set; }

        [JsonProperty("x96")]
        public string X96 { get; set; }

        [JsonProperty("x48")]
        public string X48 { get; set; }
    }

    public partial class User
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("image")]
        public UserImage Image { get; set; }

        [JsonProperty("last_online_at")]
        public DateTimeOffset LastOnlineAt { get; set; }
    }

    public partial class UserImage
    {
        [JsonProperty("x160")]
        public Uri X160 { get; set; }

        [JsonProperty("x148")]
        public Uri X148 { get; set; }

        [JsonProperty("x80")]
        public Uri X80 { get; set; }

        [JsonProperty("x64")]
        public Uri X64 { get; set; }

        [JsonProperty("x48")]
        public Uri X48 { get; set; }

        [JsonProperty("x32")]
        public Uri X32 { get; set; }

        [JsonProperty("x16")]
        public Uri X16 { get; set; }
    }
}