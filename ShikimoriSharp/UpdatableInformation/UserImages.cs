using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.UpdatableInformation
{
    public class UserImages : ApiBase
    {
        public UserImages(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<ResultImage> CreateUserImage(UserImagesSettings settings, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"comments"});
            return await Request<ResultImage, UserImagesSettings>("user_images", settings, personalInformation, "POST");
        }
    }
}