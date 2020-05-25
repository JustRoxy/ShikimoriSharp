using Newtonsoft.Json;

namespace ShikimoriSharp.Classes.Constants
{
    public class ConstantsSmileys
    {
        [JsonProperty("bbcode")] public string Bbcode { get; set; }

        [JsonProperty("path")] public string Path { get; set; }
    }

    public class ConstantsClub
    {
        [JsonProperty("join_policy")] public string[] JoinPolicy { get; set; }

        [JsonProperty("comment_policy")] public string[] CommentPolicy { get; set; }

        [JsonProperty("image_upload_policy")] public string[] ImageUploadPolicy { get; set; }
    }

    public class ConstantsUserRate
    {
        [JsonProperty("status")] public string[] Status { get; set; }
    }

    public class ConstantsAnimeManga : ConstantsUserRate
    {
        [JsonProperty("kind")] public string[] Kind { get; set; }
    }
}