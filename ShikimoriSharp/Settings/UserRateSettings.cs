#nullable enable
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Settings
{
    public class NewUserRateSettings
    {
        [JsonProperty("user_rate")] public UserRateContent content;

        public NewUserRateSettings(UserRateContent content)
        {
            this.content = content;
        }
    }

    public class UserRateEditSettings
    {
        [JsonProperty("user_rate")] public UserRateBase content;

        public UserRateEditSettings(UserRateBase content)
        {
            this.content = content;
        }
    }

    public class UserRateBase
    {
        public int? chapters;
        public int? episodes;
        public int? rewatches;
        public int? score;
        public MyList? status;
        public string? text;
        public int? volumes;
    }

    public class UserRateContent : UserRateBase
    {
        public long target_id;
        public TargetType target_type;
        public long user_id;

        public UserRateContent(long userId, long targetId, TargetType targetType)
        {
            user_id = userId;
            target_id = targetId;
            target_type = targetType;
        }
    }

    public class UserRatesSettings : BasicSettings
    {
        public MyList? status;
        public long? target_id;
        public TargetType? target_type;
        public long? user_id;
    }
}