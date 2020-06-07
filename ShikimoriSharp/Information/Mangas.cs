using System.Threading.Tasks;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.Information
{
    public class Mangas : MangaRanobeApiBase
    {
        public Mangas(ApiClient apiClient) : base("mangas", apiClient)
        {
        }
    }
}