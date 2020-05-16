using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.UpdatableInformation
{
    public class UserImages : ApiBase
    {
        public async Task<ResultImage> CreateUserImage(UserImagesSettings settings)
        {
            return await Request<ResultImage, UserImagesSettings>("user_images", settings, true, "POST");
        }
        public class UserImagesSettings
        {
            public string image;
            public string linked_type;
        }

        public class ResultImage
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("preview")]
            public string Preview { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("bbcode")]
            public string Bbcode { get; set; }
        }

        public UserImages(ApiClient apiClient) : base(Version.v1, apiClient)
        {}
    }
    
}