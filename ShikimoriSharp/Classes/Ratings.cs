using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class Ratings
    {
        [JsonProperty("anime")] public RatingsAnime[] Anime { get; set; }
    }

    public class RatingsAnime
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("value")] public long Value { get; set; }
    }

    public class Scores
    {
        [JsonProperty("anime")] public RatingsAnime[] Anime { get; set; }
        [JsonProperty("manga")] public RatingsAnime[] Manga { get; set; }
    }
}