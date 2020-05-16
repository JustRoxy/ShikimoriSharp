using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Constants : ApiBase
    {
        public class ConstantsSmileys
        {
            [JsonProperty("bbcode")]
            public string Bbcode { get; set; }

            [JsonProperty("path")]
            public string Path { get; set; }
        }
        public class ConstantsClub
        {
            [JsonProperty("join_policy")]
            public string[] JoinPolicy { get; set; }
            [JsonProperty("comment_policy")]
            public string[] CommentPolicy { get; set; }
            [JsonProperty("image_upload_policy")]
            public string[] ImageUploadPolicy { get; set; }
        }
        public class ConstantsUserRate
        {
            [JsonProperty("status")]
            public string[] Status { get; set; }
        }
        public partial class ConstantsAnimeManga : ConstantsUserRate
        {
            [JsonProperty("kind")]
            public string[] Kind { get; set; }
        }

        private async Task<ConstantsAnimeManga> Lesscode(string dest) =>
            await Request<ConstantsAnimeManga>(dest);
        public async Task<ConstantsAnimeManga> GetAnimeConstants()
            => await Lesscode("constants/anime");
        public async Task<ConstantsAnimeManga> GetMangaConstants()
            => await Lesscode("constants/manga");

        public async Task<ConstantsUserRate> GetUserRateConstants()
            => await Request<ConstantsUserRate>("constants/user_rate");
        public async Task<ConstantsClub> GetClubConstants()
            => await Request<ConstantsClub>("constants/club");
        public async Task<ConstantsSmileys> GetSmileysConstants()
            => await Request<ConstantsSmileys>("constants/smileys");
        
        public Constants(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}