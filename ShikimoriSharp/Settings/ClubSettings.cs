#nullable enable
using Newtonsoft.Json;

namespace ShikimoriSharp.Settings
{
    public class UpdateClubSettings
    {
        [JsonProperty("club")] private UpdateClubSubSettings club;

        public UpdateClubSettings(UpdateClubSubSettings club)
        {
            this.club = club;
        }
    }

    public class UpdateClubSubSettings
    {
        public string? comment_policy;
        public string? description;
        public bool? display_images;
        public string? image_upload_policy;
        public string? name;
        public string? topic_policy;
    }

    public class ClubsRequestSettings : BasicSettings
    {
        public string? search;
    }
}