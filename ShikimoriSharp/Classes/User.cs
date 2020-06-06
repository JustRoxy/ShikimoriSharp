using System;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Classes
{
    public class User
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("nickname")] public string Nickname { get; set; }
        [JsonProperty("avatar")] public Uri Avatar { get; set; }
        [JsonProperty("image")] public PureImage Image { get; set; }
        [JsonProperty("last_online_at")] public DateTimeOffset LastOnlineAt { get; set; }
    }

    public class UserLinked : Linked
    {
        [JsonProperty("topic_url")] public Uri TopicUrl { get; set; }
        [JsonProperty("thread_id")] public long ThreadId { get; set; }
        [JsonProperty("topic_id")] public long TopicId { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }

    public class BasicUser : User
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("sex")] public string Sex { get; set; }
        [JsonProperty("website")] public string Website { get; set; }
        [JsonProperty("locale")] public string Locale { get; set; }
    }

    public class UserInfo : BasicUser
    {
        [JsonProperty("birth_on")] public DateTimeOffset? BirthOn { get; set; }
    }

    public class UserId : BasicUser
    {
        [JsonProperty("full_years")] public long? FullYears { get; set; }
        [JsonProperty("last_online")] public string LastOnline { get; set; }
        [JsonProperty("location")] public string Location { get; set; }
        [JsonProperty("banned")] public bool Banned { get; set; }
        [JsonProperty("about")] public string About { get; set; }
        [JsonProperty("about_html")] public string AboutHtml { get; set; }
        [JsonProperty("common_info")] public string[] CommonInfo { get; set; }
        [JsonProperty("show_comments")] public bool? ShowComments { get; set; }
        [JsonProperty("in_friends")] public bool? InFriends { get; set; }
        [JsonProperty("is_ignored")] public bool? IsIgnored { get; set; }
        [JsonProperty("stats")] public Stats Stats { get; set; }
        [JsonProperty("style_id")] public long? StyleId { get; set; }
    }
}