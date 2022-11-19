using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Mangas : MangaRanobeApiBase
    {
        public Mangas(ApiClient apiClient) : base("mangas", apiClient)
        {
        }
    }
}