using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Classes
{
    public class ClubImage
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("original_url")] public string OriginalUrl { get; set; }
        [JsonProperty("main_url")] public string MainUrl { get; set; }
        [JsonProperty("preview_url")] public string PreviewUrl { get; set; }
        [JsonProperty("can_destroy")] public bool CanDestroy { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
    }

    public class Logo : Image
    {
        [JsonProperty("x73")] public string X73 { get; set; }
    }

    public class Club
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("logo")] public Logo Logo { get; set; }
        [JsonProperty("is_censored")] public bool? IsCensored { get; set; }
        [JsonProperty("join_policy")] public string JoinPolicy { get; set; }
        [JsonProperty("comment_policy")] public string CommentPolicy { get; set; }
    }

    public class ClubID : Club
    {
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("description_html")] public string DescriptionHtml { get; set; }
        [JsonProperty("mangas")] public Manga[] Mangas { get; set; }
        [JsonProperty("characters")] public Character[] Characters { get; set; }
        [JsonProperty("thread_id")] public long ThreadId { get; set; }
        [JsonProperty("topic_id")] public long TopicId { get; set; }
        [JsonProperty("user_role")] public object UserRole { get; set; }
        [JsonProperty("style_id")] public long StyleId { get; set; }
        [JsonProperty("members")] public User[] Members { get; set; }
        [JsonProperty("animes")] public Anime[] Animes { get; set; }
        [JsonProperty("images")] public ClubImage[] Images { get; set; }
    }
}