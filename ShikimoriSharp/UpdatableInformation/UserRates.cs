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

        public async Task<UserRate[]> NewUserRate(NewUserRateSettings settings, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"user_rates"});
            return await Request<UserRate[], NewUserRateSettings>("user_rates", settings, personalInformation, "POST");
        }

        public async Task<UserRate[]> EditUserRate(int id, UserRateEditSettings settings, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"user_rates"});
            return await Request<UserRate[], UserRateEditSettings>($"user_rates/{id}", settings, personalInformation, "PUT");
        }

        public async Task<UserRate> Increment(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"user_rates"});
            return await Request<UserRate>($"user_rates/{id}/increment", personalInformation);
        }

        public async Task DeleteUserRate(int id, AccessToken personalInformation)
        {
            Requires(personalInformation, new[] {"user_rates"});
            await NoResponseRequest($"user_rates/{id}", personalInformation);
        }
    }
}