using System.Threading.Tasks;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.UpdatableInformation
{
    public class TopicIgnores : ApiBase
    {
        public TopicIgnores(ApiClient apiClient) : base(Version.v2, apiClient)
        {
        }

        public async Task Ignore(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"ignores"});
            await NoResponseRequest($"topics/{id}/ignore", personalInformation);
        }

        public async Task UnIgnore(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"ignores"});
            await NoResponseRequest($"topics/{id}/ignore", personalInformation, method: "DELETE");
        }
    }
}