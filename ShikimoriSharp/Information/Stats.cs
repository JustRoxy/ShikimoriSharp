using System.Threading.Tasks;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Stats : ApiBase
    {
        /// <summary>
        /// Be careful of this function. The estimated time of execution is very high
        /// </summary>
        /// <returns></returns>
        public async Task<int[]> GetActiveUsers()
            => await Request<int[]>($"stats/active_users");
        
        public Stats(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }
    }
}