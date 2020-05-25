using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class Stats
    {
        [JsonProperty("statuses")] public Statuses Statuses { get; set; }
        [JsonProperty("full_statuses")] public Statuses FullStatuses { get; set; }
        [JsonProperty("scores")] public Scores Scores { get; set; }
        [JsonProperty("types")] public Scores Types { get; set; }
        [JsonProperty("ratings")] public Ratings Ratings { get; set; }
        [JsonProperty("has_anime?")] public bool HasAnime { get; set; }
        [JsonProperty("has_manga?")] public bool HasManga { get; set; }
        [JsonProperty("genres")] public Genre[] Genres { get; set; }
        [JsonProperty("studios")] public Studio[] Studios { get; set; }
        [JsonProperty("publishers")] public Publisher[] Publishers { get; set; }
        [JsonProperty("activity")] public Activity[] Activity { get; set; }
    }
}