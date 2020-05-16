using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Clubs : ApiBase
    {
        public class Logo : Image
        {
            [JsonProperty("x73")]
            public string X73 { get; set; }
        }
        public class Club
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("logo")]
            public Logo Logo { get; set; }

            [JsonProperty("is_censored")]
            public bool IsCensored { get; set; }

            [JsonProperty("join_policy")]
            public string JoinPolicy { get; set; }

            [JsonProperty("comment_policy")]
            public string CommentPolicy { get; set; }
        }
        public Clubs(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}