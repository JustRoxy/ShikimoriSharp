using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Information
{
    public class Ranobe : MangaRanobeApiBase
    {
        public Ranobe(ApiClient apiClient) : base("ranobe", apiClient)
        {
        }
    }
}