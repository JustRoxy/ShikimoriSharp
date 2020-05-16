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
        public string Name { get; set; }

        [JsonProperty("russian")]
        public object Russian { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("score")]
        public string Score { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("episodes")]
        public long Episodes { get; set; }

        [JsonProperty("episodes_aired")]
        public long EpisodesAired { get; set; }

        [JsonProperty("aired_on")]
        public DateTimeOffset AiredOn { get; set; }

        [JsonProperty("released_on")]
        public object ReleasedOn { get; set; }
    }
}