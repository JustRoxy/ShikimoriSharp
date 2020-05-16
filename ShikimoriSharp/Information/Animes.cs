#nullable enable
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Enums;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class Animes : ApiBase
    {
        public async Task<Anime[]> GetAnimeAsync(AnimeRequestSettings settings)
        {
            return await Request<Anime[], AnimeRequestSettings>("animes", settings);
        }

        public async Task<AnimeID> GetAnimeByIdAsync(int id)
            => await Request<AnimeID>($"animes/{id}");
        public async Task<Role[]> GetRolesAsync(int id)
            => await Request<Role[]>($"animes/{id}/roles");
        public async Task<Anime[]> GetSimilarAsync(int id)
            => await Request<Anime[]>($"animes/{id}/similar");
        public async Task<Related[]> GetRelatedAsync(int id)
            => await Request<Related[]>($"animes/{id}/related");
        public async Task<Screenshots[]> GetScreenshotsAsync(int id)
            => await Request<Screenshots[]>($"animes/{id}/screenshots");
        public async Task<Franchise> GetFranchiseAsync(int id)
            => await Request<Franchise>($"animes/{id}/franchise");
        public async Task<ExternalLinks[]> GetExternalLinksAsync(int id)
            => await Request<ExternalLinks[]>($"animes/{id}/external_links");

        public async Task<Topic[]> GetTopicsAsync(int id)
            => await Request<Topic[]>($"animes/{id}/topics");
        public async Task<Topic[]> GetTopicsAsync(int id, AnimeTopicSettings settings)
            => await Request<Topic[], AnimeTopicSettings>($"animes/{id}/topics", settings);
        public class AnimeTopicSettings : BasicSettings
        {
            public int episode;
            public string? kind;
        }

        public class Screenshots
        {
            [JsonProperty("original")]
            public string Original { get; set; }

            [JsonProperty("preview")]
            public string Preview { get; set; }
        }
        
        public class AnimeID : AnimeMangaIdBase
        {
            [JsonProperty("episodes")] public long Episodes { get; set; }

            [JsonProperty("episodes_aired")] public long EpisodesAired { get; set; }

            [JsonProperty("rating")] public string Rating { get; set; }

            [JsonProperty("duration")] public long Duration { get; set; }

            [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }

            [JsonProperty("next_episode_at")] public object NextEpisodeAt { get; set; }

            [JsonProperty("studios")] public object[] Studios { get; set; }

            [JsonProperty("videos")] public object[] Videos { get; set; }

            [JsonProperty("screenshots")] public object[] Screenshots { get; set; }
        }
      
        public class AnimeRequestSettings : MangaAnimeRequestSettingsBase
        {
            public int[]? studio;
        }

        public Animes(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }
    }
    
    public class Anime : AnimeMangaBase
    {
        [JsonProperty("episodes")]
        public long Episodes { get; set; }

        [JsonProperty("episodes_aired")]
        public long EpisodesAired { get; set; }
    }
}