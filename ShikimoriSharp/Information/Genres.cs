using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Genres : ApiBase
    {
        public partial class Genre
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("russian")]
            public object Russian { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }
        }
        public async Task<Genre[]> GetGenresAsync()
            => await Request<Genre[]>("genres");
        public Genres(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
}