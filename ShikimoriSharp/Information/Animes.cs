using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Enums;
using ShikimoriSharp.UpdatableInformation;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class Animes : ApiBase
    {
        public Animes(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Anime[]> GetAnime(AnimeRequestSettings settings)
        {
            var personalRequest = !(settings.mylist is null);
            return await Request<Anime[], AnimeRequestSettings>("animes", settings, personalRequest);
        }

        public async Task<AnimeID> GetAnimeById(long id)
        {
            return await Request<AnimeID>($"animes/{id}", true);
        }

        public async Task<Role[]> GetRoles(long id)
        {
            return await Request<Role[]>($"animes/{id}/roles");
        }

        public async Task<Anime[]> GetSimilar(long id)
        {
            return await Request<Anime[]>($"animes/{id}/similar");
        }

        public async Task<Related[]> GetRelated(long id)
        {
            return await Request<Related[]>($"animes/{id}/related");
        }

        public async Task<Screenshots[]> GetScreenshots(long id)
        {
            return await Request<Screenshots[]>($"animes/{id}/screenshots");
        }

        public async Task<Franchise> GetFranchise(long id)
        {
            return await Request<Franchise>($"animes/{id}/franchise");
        }

        public async Task<ExternalLinks[]> GetExternalLinks(long id)
        {
            return await Request<ExternalLinks[]>($"animes/{id}/external_links");
        }

        public async Task<Topic[]> GetTopics(long id)
        {
            return await Request<Topic[]>($"animes/{id}/topics");
        }

        public async Task<Topic[]> GetTopics(long id, AnimeTopicSettings settings)
        {
            return await Request<Topic[], AnimeTopicSettings>($"animes/{id}/topics", settings);
        }

        public class AnimeTopicSettings : BasicSettings
        {
            public int? episode;
            public string? kind;
        }

        public class Screenshots
        {
            [JsonProperty("original")] public string Original { get; set; }

            [JsonProperty("preview")] public string Preview { get; set; }
        }

        public class AnimeID : AnimeMangaIdBase
        {
            [JsonProperty("episodes")] public long? Episodes { get; set; }

            [JsonProperty("episodes_aired")] public long? EpisodesAired { get; set; }

            [JsonProperty("rating")] public string Rating { get; set; }

            [JsonProperty("duration")] public long? Duration { get; set; }

            [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

            [JsonProperty("next_episode_at")] public object NextEpisodeAt { get; set; }

            [JsonProperty("studios")] public Studios.Studio[] Studios { get; set; }

            [JsonProperty("videos")] public Videos.Video[] Videos { get; set; }

            [JsonProperty("screenshots")] public Screenshots[] Screens { get; set; }
        }

        public class AnimeRequestSettings : MangaAnimeRequestSettingsBase
        {
            public Duration? duration;
            public int[]? studio;
        }
    }

    public class Anime : AnimeMangaBase
    {
        [JsonProperty("episodes")] public long? Episodes { get; set; }

        [JsonProperty("episodes_aired")] public long? EpisodesAired { get; set; }
    }
}