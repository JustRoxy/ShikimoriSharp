using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.UpdatableInformation
{
    public class UserRates : ApiBase
    {
        public UserRates(ApiClient apiClient) : base(Version.v2, apiClient)
        {
        }

        public async Task<UserRate[]> GetUserRates(long id)
        {
            return await Request<UserRate[]>($"user_rates/{id}");
        }

        public async Task<UserRate[]> GetUsersRates(UserRatesSettings settings)
        {
            return await Request<UserRate[], UserRatesSettings>("user_rates", settings);
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
    }
}