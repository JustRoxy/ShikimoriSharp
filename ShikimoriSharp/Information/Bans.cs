using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;

namespace ShikimoriSharp.Information
{
    public class Bans : ApiBase
    {
        public Bans(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Ban[]> GetBans()
        {
            return await Request<Ban[]>("bans");
        }
    }
}