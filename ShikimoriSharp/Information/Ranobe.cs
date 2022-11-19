using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Ranobe : MangaRanobeApiBase
    {
        public Ranobe(ApiClient apiClient) : base("ranobe", apiClient)
        {
        }
    }
}