#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Settings
{
    public class EditTopicSettingsContent
    {
        public string? body;
        public int? linked_id;
        public LinkedType? linked_type;
        public string? title;
    }

    public class EditTopicSettings
    {
        [JsonProperty("topic")] public EditTopicSettingsContent topic;

        public EditTopicSettings(EditTopicSettingsContent content)
        {
            topic = content;
        }
    }

    public class CreateTopicSettings
    {
        public Dictionary<string, Dictionary<string, string>> topic =
            new Dictionary<string, Dictionary<string, string>>();

        public CreateTopicSettings(string body, int forum_id, string title, int user_id, int? linked_id = null,
            LinkedType? linked_type = null)
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
    }

    public class TopicSettings : BasicSettings
    {
        public Forum? forum;
        public int? linked_id;
        public LinkedType? linked_type;
    }
}