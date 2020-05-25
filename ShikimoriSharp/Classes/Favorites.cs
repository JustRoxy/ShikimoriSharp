using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Classes
{
    public class Favorites
    {
        [JsonProperty("animes")] public SmallRepresentation[] Animes { get; set; }
        [JsonProperty("mangas")] public SmallRepresentation[] Mangas { get; set; }
        [JsonProperty("characters")] public SmallRepresentation[] Characters { get; set; }
        [JsonProperty("people")] public SmallRepresentation[] People { get; set; }
        [JsonProperty("mangakas")] public SmallRepresentation[] Mangakas { get; set; }
        [JsonProperty("seyu")] public SmallRepresentation[] Seyu { get; set; }
        [JsonProperty("producers")] public SmallRepresentation[] Producers { get; set; }
    }
}