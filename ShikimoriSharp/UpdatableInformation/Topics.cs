using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Topics : ApiBase
    {
        public async Task<Topic[]> GetTopics(TopicSettings settings = null)
        {
            return await Request<Topic[], TopicSettings>($"topics", settings);
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

        public class EditTopicSettingsContent
        {
            public string? body;
            public int? linked_id;
            public LinkedType? linked_type;
            public string? title;
        }
        public class EditTopicSettings
        {
            public EditTopicSettings(EditTopicSettingsContent content)
            {
                topic = content;
            }

            [JsonProperty("topic")]
            public EditTopicSettingsContent topic;
            
        }
        
        public class CreateTopicSettings
        {
            public CreateTopicSettings(string body, int forum_id, string title, int user_id, int? linked_id = null, LinkedType? linked_type = null)
            {
                topic.Add("topic", new Dictionary<string, string>
                {
                    {"body", body},
                    {"forum_id", forum_id.ToString()},
                    {"title", title},
                    {"type", "Topic"},
                    {"user_id", user_id.ToString()}
                });
                if (linked_id is null || linked_type is null) return;
                topic["topic"].Add("linked_id", linked_id.ToString());
                topic["topic"].Add("linked_type", linked_type.ToString());

            }
            public Dictionary<string, Dictionary<string, string>> topic = new Dictionary<string, Dictionary<string, string>>();
        }


        public class ExtendedLightTopic : LightTopic
        {
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class TopicSettings : BasicSettings
        {
            public Forum forum;
            public int? linked_id;
            public LinkedType? linked_type;
        }

        public enum LinkedType
        {
            Anime, Manga, Ranobe, Character, Person, Club, ClubPage, Review, Contest, CosplayGallery, Collection, Article
        }
        public Topics(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}