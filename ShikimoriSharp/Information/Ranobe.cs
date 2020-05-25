using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Information
{
    public class Ranobe : ApiBase
    {
        public Ranobe(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Manga> GetRanobe()
        {
            return await Request<Manga>("ranobe");
        }

        public async Task<Manga> GetRanobe(MangaRequestSettings settings)
        {
            return await Request<Manga, MangaRequestSettings>("ranobe", settings);
        }

        public async Task<MangaID> GetRanobeById(int id)
        {
            return await Request<MangaID>($"ranobe/{id}");
        }

        public async Task<Manga> GetSimilar(int id)
        {
            return await Request<Manga>($"ranobe/{id}/similar");
        }

        public async Task<Related> GetRelated(int id)
        {
            return await Request<Related>($"ranobe/{id}/related");
        }

        public async Task<Franchise> GetFranchise(int id)
        {
            return await Request<Franchise>($"ranobe/{id}/franchise");
        }

        public async Task<ExternalLinks> GetExternalLinks(int id)
        {
            return await Request<ExternalLinks>($"ranobe/{id}/external_links");
        }

        public async Task<Topic> GetTopics(int id)
        {
            return await Request<Topic>($"ranobe/{id}/topics");
        }

        public async Task<Topic> GetTopics(int id, BasicSettings settings)
        {
            return await Request<Topic, BasicSettings>($"ranobe/{id}/topics", settings);
        }
    }
}