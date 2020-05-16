#nullable enable
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Information
{
    public class Animes : ApiBase
    {
        

        public async Task<Anime[]> GetAnimeAsync(AnimeRequestSettings settings)
        {
            return await Request<Anime[], AnimeRequestSettings>("animes", settings);
        }

        public async Task<FullAnime> GetAnimeByIdAsync(int id)
        {
            return await Request<FullAnime>($"animes/{id}");
        }

        public class AnimeRequestSettings
        {
            public int? page;
            public int? limit;
            public Order? order;
            public Kind? kind;
            public Status? status;
            public string? seasons;
            public int? score;
            public int[]? genre;
            public int[]? studio;
            public int[]? franchise;
            public bool? censored;
            public MyList? mylist;
            public int[]? ids;
            public int[]? exclude_ids;
            public string? search;
        }

        public Animes(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }
    }

    public class Anime
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("russian")]
        public object? Russian { get; set; }

        [JsonProperty("image")]
        public Image? Image { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("kind")]
        public string? Kind { get; set; }

        [JsonProperty("score")]
        public string? Score { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("episodes")]
        public long Episodes { get; set; }

        [JsonProperty("episodes_aired")]
        public long EpisodesAired { get; set; }

        [JsonProperty("aired_on")]
        public DateTimeOffset AiredOn { get; set; }

        [JsonProperty("released_on")]
        public object? ReleasedOn { get; set; }
    }

    public class FullAnime : Anime
    {
        [JsonProperty("rating")]
        public string? Rating { get; set; }

        [JsonProperty("english")]
        public object[]? English { get; set; }

        [JsonProperty("japanese")]
        public object[]? Japanese { get; set; }

        [JsonProperty("synonyms")]
        public object[]? Synonyms { get; set; }

        [JsonProperty("license_name_ru")]
        public object? LicenseNameRu { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("description")]
        public object? Description { get; set; }

        [JsonProperty("description_html")]
        public string? DescriptionHtml { get; set; }

        [JsonProperty("description_source")]
        public object? DescriptionSource { get; set; }

        [JsonProperty("franchise")]
        public object? Franchise { get; set; }

        [JsonProperty("favoured")]
        public bool Favoured { get; set; }

        [JsonProperty("anons")]
        public bool Anons { get; set; }

        [JsonProperty("ongoing")]
        public bool Ongoing { get; set; }

        [JsonProperty("thread_id")]
        public long ThreadId { get; set; }

        [JsonProperty("topic_id")]
        public long TopicId { get; set; }

        [JsonProperty("myanimelist_id")]
        public long MyanimelistId { get; set; }

        [JsonProperty("rates_scores_stats")]
        public object[]? RatesScoresStats { get; set; }

        [JsonProperty("rates_statuses_stats")]
        public object[]? RatesStatusesStats { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("next_episode_at")]
        public object? NextEpisodeAt { get; set; }

        [JsonProperty("genres")]
        public object[]? Genres { get; set; }

        [JsonProperty("studios")]
        public object[]? Studios { get; set; }

        [JsonProperty("videos")]
        public object[]? Videos { get; set; }

        [JsonProperty("screenshots")]
        public object[]? Screenshots { get; set; }

        [JsonProperty("user_rate")]
        public object? UserRate { get; set; }
    }
}