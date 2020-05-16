using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using static ShikimoriSharp.Information.Mangas;

namespace ShikimoriSharp.Information
{
    public class Ranobe : ApiBase
    {

        public async Task<Manga> GetRanobe()
            => await Request<Manga>($"ranobe");
        public async Task<Manga> GetRanobe(MangaRequestSettings settings)
            => await Request<Manga, MangaRequestSettings>("ranobe", settings);

        public async Task<MangaID> GetRanobeById(int id)
            => await Request<MangaID>($"ranobe/{id}");
        public async Task<Manga> GetSimilar(int id)
            => await Request<Manga>($"ranobe/{id}/similar");
        public async Task<Related> GetRelated(int id)
            => await Request<Related>($"ranobe/{id}/related");
        public async Task<Franchise> GetFranchise(int id)
            => await Request<Franchise>($"ranobe/{id}/franchise");
        public async Task<ExternalLinks> GetExternalLinks(int id)
            => await Request<ExternalLinks>($"ranobe/{id}/external_links");
        public async Task<Topic> GetTopics(int id)
            => await Request<Topic>($"ranobe/{id}/topics");

        public async Task<Topic> GetTopics(int id, BasicSettings settings)
            => await Request<Topic, BasicSettings>($"ranobe/{id}/topics", settings);
        
        public Ranobe(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}