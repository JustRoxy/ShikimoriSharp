using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;

namespace ShikimoriSharp.Information
{
    public class Calendars : ApiBase
    {
        public Calendars(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Calendar[]> GetCalendar()
        {
            return await Request<Calendar[]>("calendar");
        }
    }
}