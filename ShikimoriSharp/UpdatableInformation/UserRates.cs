using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Enums;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class UserRates : ApiBase
    {
        public async Task<UserRate[]> GetUserRates(int id)
        {
            return await Request<UserRate[]>($"user_rates/{id}");
        }
        public async Task<UserRate[]> GetUsersRates(UserRatesSettings settings)
        {
            return await Request<UserRate[], UserRatesSettings>($"user_rates", settings);
        }

        public async Task<UserRate[]> NewUserRate(NewUserRateSettings settings)
        {
            return await Request<UserRate[], NewUserRateSettings>("user_rates", settings, true, "POST");
        }
        
        public async Task<UserRate[]> EditUserRate(int id, UserRateEditSettings settings)
        {
            return await Request<UserRate[], UserRateEditSettings>($"user_rates/{id}", settings, true, "PUT");
        }

        public async Task<UserRate> Increment(int id)
        {
            return await Request<UserRate>($"user_rates/{id}/increment", true);
        }

        public async Task DeleteUserRate(int id)
        {
            await NoResponseRequest($"user_rates/{id}");
        }
        

        public class NewUserRateSettings
        {
            public NewUserRateSettings(UserRateContent content)
            {
                this.content = content;
            }
            [JsonProperty("user_rate")] public UserRateContent content;
        }
        public class UserRateEditSettings
        {
            public UserRateEditSettings(UserRateBase content)
            {
                this.content = content;
            }
            [JsonProperty("user_rate")] public UserRateBase content;
        }
        public class UserRateBase
        {
            public MyList status;
            public int score;
            public int chapters;
            public int episodes;
            public int volumes;
            public int rewatches;
            public string text;
        }
        public class UserRateContent : UserRateBase
        {
            public long user_id;
            public long target_id;
            public TargetType target_type;
            public MyList status;
            public int score;
            

            public UserRateContent(long userId, long targetId, TargetType targetType)
            {
                user_id = userId;
                target_id = targetId;
                target_type = targetType;
            }
        }

        public class UserRatesSettings : BasicSettings
        {
            public int user_id;
            public int target_id;
            public TargetType target_type;
            public MyList status;
        }

        public enum TargetType
        {
            Anime,
            Manga
        }
        
        public class UserRate
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("user_id")]
            public long UserId { get; set; }

            [JsonProperty("target_id")]
            public long TargetId { get; set; }

            [JsonProperty("target_type")]
            public string TargetType { get; set; }

            [JsonProperty("score")]
            public long Score { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("rewatches")]
            public long Rewatches { get; set; }

            [JsonProperty("episodes")]
            public long Episodes { get; set; }

            [JsonProperty("volumes")]
            public long Volumes { get; set; }

            [JsonProperty("chapters")]
            public long Chapters { get; set; }

            [JsonProperty("text")]
            public object Text { get; set; }

            [JsonProperty("text_html")]
            public object TextHtml { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }
        }
        public UserRates(ApiClient apiClient) : base(Version.v2, apiClient)
        {}
    }
}