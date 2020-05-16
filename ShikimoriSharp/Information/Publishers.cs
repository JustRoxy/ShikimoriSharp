using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Publishers : ApiBase
    {
        public Publishers(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Publisher[]> GetPerson(int id)
        {
            return await Request<Publisher[]>($"publishers/{id}");
        }

        public class Publisher
        {
            [JsonProperty("id")] public long Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }
        }
    }
}