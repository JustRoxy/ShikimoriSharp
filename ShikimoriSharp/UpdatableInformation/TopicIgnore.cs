using System.Threading.Tasks;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.UpdatableInformation
{
    public class TopicIgnores : ApiBase
    {
        public TopicIgnores(ApiClient apiClient) : base(Version.v2, apiClient)
        {
        }

        public async Task Ignore(int id)
        {
            await NoResponseRequest($"topics/{id}/ignore");
        }

        public async Task UnIgnore(int id)
        {
            await NoResponseRequest($"topics/{id}/ignore", method: "DELETE");
        }
    }
}