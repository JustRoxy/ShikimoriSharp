using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Forums : ApiBase
    {
        public class Forum
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("position")]
            public long Position { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("permalink")]
            public string Permalink { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public async Task<Forum[]> GetForumsAsync()
            => await Request<Forum[]>("forums");
        public Forums(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}