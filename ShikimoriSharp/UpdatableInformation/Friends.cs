using System.Threading.Tasks;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Friends : ApiBase
    {
        public Friends(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task AddFriend(int id)
        {
            await NoResponseRequest($"friends/{id}");
        }

        public async Task DeleteFriend(int id)
        {
            await NoResponseRequest($"friends/{id}", method: "DELETE");
        }
    }
}