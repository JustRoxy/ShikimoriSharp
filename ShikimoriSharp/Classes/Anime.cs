using System;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Classes
{
    public class Anime : AnimeMangaBase
    {
        [JsonProperty("episodes")] public long Episodes { get; set; }
        [JsonProperty("episodes_aired")] public long EpisodesAired { get; set; }
    }

    public class AnimeID : AnimeMangaIdBase
    {
        [JsonProperty("episodes")] public long Episodes { get; set; }
        [JsonProperty("episodes_aired")] public long EpisodesAired { get; set; }
        [JsonProperty("rating")] public string Rating { get; set; }
        [JsonProperty("duration")] public long Duration { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
        [JsonProperty("next_episode_at")] public DateTimeOffset? NextEpisodeAt { get; set; }
        [JsonProperty("studios")] public Studio[] Studios { get; set; }
        [JsonProperty("videos")] public Video[] Videos { get; set; }
        [JsonProperty("screenshots")] public Screenshots[] Screens { get; set; }
    }
}