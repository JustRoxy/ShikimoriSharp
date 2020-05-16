using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Mangas : ApiBase
    {
        public async Task<Manga[]> GetMangaAsync()
            => await Request<Manga[]>("mangas");
        public async Task<Manga[]> GetMangaAsync(MangaRequestSettings settings)
            => await Request<Manga[], MangaRequestSettings>("mangas", settings);

        public async Task<MangaID> GetMangaAsync(int id)
            => await Request<MangaID>($"mangas/{id}");

        public async Task<Role[]> GetRolesAsync(int id)
            => await Request<Role[]>($"mangas/{id}/roles");
        public async Task<Manga[]> GetSimilarAsync(int id)
            => await Request<Manga[]>($"mangas/{id}/similar");
        public async Task<Related[]> GetRelatedAsync(int id)
            => await Request<Related[]>($"mangas/{id}/related");
        public async Task<Franchise> GetFranchiseAsync(int id)
            => await Request<Franchise>($"mangas/{id}/franchise");
        public async Task<ExternalLinks[]> GetExternalLinksAsync(int id)
            => await Request<ExternalLinks[]>($"mangas/{id}/external_links");
        public async Task<Topic> GetTopicsAsync(int id)
            => await Request<Topic>($"mangas/{id}/topics");
        public async Task<Topic> GetTopicsAsync(int id, BasicSettings settings)
            => await Request<Topic, BasicSettings>($"mangas/{id}/topics", settings);


        public class MangaID : AnimeMangaIdBase
        {
            [JsonProperty("volumes")] public long Volumes { get; set; }
            [JsonProperty("chapters")] public long Chapters { get; set; }
            [JsonProperty("publishers")] public object[] Publishers { get; set; }
        }
        public class Manga : AnimeMangaBase
        {
            [JsonProperty("volumes")]
            public long? Volumes { get; set; }

            [JsonProperty("chapters")]
            public long? Chapters { get; set; }
        }

        public class MangaRequestSettings : MangaAnimeRequestSettingsBase
        {
            public int[]? publisher;
        }
        public Mangas(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}