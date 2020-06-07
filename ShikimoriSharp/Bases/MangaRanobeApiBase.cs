using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Bases
{
    public class MangaRanobeApiBase : ApiBase
    {
        private readonly string _query;

        public MangaRanobeApiBase(string query, ApiClient apiClient) : base(Version.v1, apiClient)
        {
            _query = query;
        }
        
        public async Task<Manga[]> GetBySearch(MangaRequestSettings settings = null, AccessToken personalInformation = null)
        {
            return await Request<Manga[], MangaRequestSettings>($"{_query}", settings, personalInformation);
        }

        public async Task<MangaID> GetById(long id, AccessToken personalInformation = null)
        {
            return await Request<MangaID>($"{_query}/{id}", personalInformation);
        }

        public async Task<Role[]> GetRoles(long id)
        {
            return await Request<Role[]>($"{_query}/{id}/roles");
        }

        public async Task<Manga[]> GetSimilar(long id, AccessToken personalInformation = null)
        {
            return await Request<Manga[]>($"{_query}/{id}/similar", personalInformation);
        }

        public async Task<Related[]> GetRelated(long id, AccessToken personalInformation = null)
        {
            return await Request<Related[]>($"{_query}/{id}/related", personalInformation);
        }

        public async Task<Franchise> GetFranchise(long id)
        {
            return await Request<Franchise>($"{_query}/{id}/franchise");
        }

        public async Task<ExternalLinks[]> GetExternalLinks(long id)
        {
            return await Request<ExternalLinks[]>($"{_query}/{id}/external_links");
        }

        public async Task<Topic[]> GetTopics(long id, AccessToken personalInformation = null)
        {
            return await Request<Topic[]>($"{_query}/{id}/topics", personalInformation);
        }

        public async Task<Topic[]> GetTopics(long id, BasicSettings settings, AccessToken personalInformation = null)
        {
            return await Request<Topic[], BasicSettings>($"{_query}/{id}/topics", settings, personalInformation);
        }
    }
}