using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Studios : ApiBase
    {
        public Studios(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Studio[]> GetStudios()
        {
            return await Request<Studio[]>("studios");
        }

        public class Studio
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("filtered_name")] public string FilteredName { get; set; }

            [JsonProperty("real")] public bool? Real { get; set; }

            [JsonProperty("image")] public object Image { get; set; }
        }
    }
}