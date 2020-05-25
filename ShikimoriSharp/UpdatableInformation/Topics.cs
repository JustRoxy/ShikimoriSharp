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

        public async Task<Topic[]> GetTopics(TopicSettings settings = null)
        {
            return await Request<Topic[], TopicSettings>("topics", settings);
        }

        public async Task<ExtendedLightTopic[]> GetUpdates(BasicSettings settings = null)
        {
            return await Request<ExtendedLightTopic[], BasicSettings>("topics/updates", settings);
        }

        public async Task<Topic> GetTopics(int id)
        {
            return await Request<Topic>($"topics/{id}");
        }

        public async Task<Topic> CreateTopic(CreateTopicSettings settings)
        {
            return await SendJson<Topic>("topics", settings, true);
        }

        public async Task DeleteTopic(int id)
        {
            await NoResponseRequest($"topics/{id}");
        }
    }
}