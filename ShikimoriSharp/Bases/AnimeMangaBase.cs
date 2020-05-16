#nullable enable
using System;
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Bases
{
    public class AnimeMangaBase
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
        [JsonProperty("aired_on")]
        public DateTimeOffset AiredOn { get; set; }

        [JsonProperty("released_on")]
        public object? ReleasedOn { get; set; }
    }

    public class BasicSettings
    {
        public int? page;
        public int? limit;
    }
    public class MangaAnimeRequestSettingsBase : BasicSettings
    {
        public string? kind;
        public string? order;
        public string? status;
        public string? seasons;
        public int? score;
        public int[]? genre;
        public int[]? franchise;
        public bool? censored;
        public MyList? mylist;
        public int[]? ids;
        public int[]? exclude_ids;
        public string? search;
    }
}