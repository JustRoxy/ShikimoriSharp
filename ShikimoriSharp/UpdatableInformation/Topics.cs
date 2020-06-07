using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Topics : ApiBase
    {
        public Topics(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Topic[]> GetTopics(TopicSettings settings = null, AccessToken personalInformation = null)
        {
            return await Request<Topic[], TopicSettings>("topics", settings, personalInformation);
        }

        public async Task<ExtendedLightTopic[]> GetUpdates(BasicSettings settings = null)
        {
            return await Request<ExtendedLightTopic[], BasicSettings>("topics/updates", settings);
        }

        public async Task<Topic> GetTopics(int id, AccessToken personalInformation = null)
        {
            return await Request<Topic>($"topics/{id}", personalInformation);
        }

        public async Task<Topic> CreateTopic(CreateTopicSettings settings, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"topics"});
            return await SendJson<Topic>("topics", settings, personalInformation);
        }

        public async Task DeleteTopic(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"topics"});
            await NoResponseRequest($"topics/{id}", personalInformation);
        }
    }
}