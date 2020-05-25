using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;

namespace ShikimoriSharp.Information
{
    public class Genres : ApiBase
    {
        public Genres(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Genre[]> GetGenres()
        {
            return await Request<Genre[]>("genres");
        }
    }
}