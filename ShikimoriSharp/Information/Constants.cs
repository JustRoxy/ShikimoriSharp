using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Constants : ApiBase
    {
        public Constants(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        private async Task<ConstantsAnimeManga> Lesscode(string dest)
        {
            return await Request<ConstantsAnimeManga>(dest);
        }

        public async Task<ConstantsAnimeManga> GetAnimeConstants()
        {
            return await Lesscode("constants/anime");
        }

        public async Task<ConstantsAnimeManga> GetMangaConstants()
        {
            return await Lesscode("constants/manga");
        }

        public async Task<ConstantsUserRate> GetUserRateConstants()
        {
            return await Request<ConstantsUserRate>("constants/user_rate");
        }

        public async Task<ConstantsClub> GetClubConstants()
        {
            return await Request<ConstantsClub>("constants/club");
        }

        public async Task<ConstantsSmileys> GetSmileysConstants()
        {
            return await Request<ConstantsSmileys>("constants/smileys");
        }

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
}