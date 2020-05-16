using Newtonsoft.Json;
using ShikimoriSharp.Information;

namespace ShikimoriSharp.AdditionalRequests
{
    public class Related
    {
        [JsonProperty("relation")] public string Relation { get; set; }

        [JsonProperty("relation_russian")] public string RelationRussian { get; set; }

        [JsonProperty("anime")] public Anime Anime { get; set; }

        [JsonProperty("manga")] public Mangas.Manga Manga { get; set; }
    }
}