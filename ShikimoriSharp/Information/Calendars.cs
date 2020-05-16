using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class Calendars : ApiBase
    {
        public Calendars(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Calendar[]> GetCalendarAsync()
        {
            return await Request<Calendar[]>("calendar");
        }
    }

    public class Calendar
    {
        [JsonProperty("next_episode")] public long NextEpisode { get; set; }

        [JsonProperty("next_episode_at")] public DateTimeOffset NextEpisodeAt { get; set; }

        [JsonProperty("duration")] public string Duration { get; set; }

        [JsonProperty("anime")] public Anime Anime { get; set; }
    }
}