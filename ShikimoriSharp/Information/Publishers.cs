using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Publishers : ApiBase
    {
        public async Task<Publisher[]> GetPerson(int id)
            => await Request<Publisher[]>($"publishers/{id}");

        public class Publisher
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
        public Publishers(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }
    }
}