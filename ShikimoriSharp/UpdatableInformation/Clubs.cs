using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Clubs : ApiBase
    {
        public Clubs(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Club[]> GetClubs(ClubsRequestSettings settings = null)
        {
            return await Request<Club[], ClubsRequestSettings>("clubs", settings, true);
        }

        public async Task<Club> UpdateClub(int id, UpdateClubSettings club = null)
        {
            return await SendJson<Club>($"clubs/{id}", club, true, "PUT");
        }

        public async Task<Anime[]> GetAnimes(int id)
        {
            return await Request<Anime[]>($"clubs/{id}/animes");
        }

        public async Task<Mangas.Manga[]> GetMangas(int id)
        {
            return await Request<Mangas.Manga[]>($"clubs/{id}/mangas");
        }

        public async Task<Mangas.Manga[]> GetRanobe(int id)
        {
            return await Request<Mangas.Manga[]>($"clubs/{id}/ranobe");
        }

        public async Task<Characters.Character[]> GetCharacters(int id)
        {
            return await Request<Characters.Character[]>($"clubs/{id}/characters");
        }

        public async Task<Users.User[]> GetMembers(int id)
        {
            return await Request<Users.User[]>($"clubs/{id}/members");
        }

        public async Task<ClubImage[]> GetImages(int id)
        {
            return await Request<ClubImage[]>($"clubs/{id}/images");
        }

        public async Task Join(int id)
        {
            await NoResponseRequest($"clubs/{id}/join");
        }

        public async Task Leave(int id)
        {
            await NoResponseRequest($"clubs/{id}/leave");
        }

        public class ClubImage
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("original_url")] public string OriginalUrl { get; set; }

            [JsonProperty("main_url")] public string MainUrl { get; set; }

            [JsonProperty("preview_url")] public string PreviewUrl { get; set; }

            [JsonProperty("can_destroy")] public object CanDestroy { get; set; }

            [JsonProperty("user_id")] public long? UserIdUserId { get; set; }
        }

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

        public class Logo : Image
        {
            [JsonProperty("x73")] public string X73 { get; set; }
        }

        public class Club
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("logo")] public Logo Logo { get; set; }

            [JsonProperty("is_censored")] public bool? IsCensored { get; set; }

            [JsonProperty("join_policy")] public string JoinPolicy { get; set; }

            [JsonProperty("comment_policy")] public string CommentPolicy { get; set; }
        }

        public class ClubID : Club
        {
            [JsonProperty("description")] public object Description { get; set; }

            [JsonProperty("description_html")] public string DescriptionHtml { get; set; }

            [JsonProperty("mangas")] public object[] Mangas { get; set; }

            [JsonProperty("characters")] public object[] Characters { get; set; }

            [JsonProperty("thread_id")] public long? ThreadId { get; set; }

            [JsonProperty("topic_id")] public long? TopicId { get; set; }

            [JsonProperty("user_role")] public object UserRole { get; set; }

            [JsonProperty("style_id")] public object StyleId { get; set; }

            [JsonProperty("members")] public object[] Members { get; set; }

            [JsonProperty("animes")] public object[] Animes { get; set; }

            [JsonProperty("images")] public object[] Images { get; set; }
        }
    }
}