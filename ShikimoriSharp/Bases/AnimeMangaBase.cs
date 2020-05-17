using System;
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Bases
{
    public class SmallRepresentation
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("russian")] public object Russian { get; set; }

        [JsonProperty("image")] public Image Image { get; set; }

        [JsonProperty("url")] public string Url { get; set; }
    }

    public class AnimeMangaBase : SmallRepresentation
    {
        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("score")] public string Score { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("aired_on")] public DateTimeOffset? AiredOn { get; set; }

        [JsonProperty("released_on")] public object ReleasedOn { get; set; }
    }

    public class BasicSettings
    {
        public int? limit;
        public int? page;
    }


    public class MangaAnimeRequestSettingsBase : BasicSettings
    {
        public bool? censored;
        public int[]? exclude_ids;
        public int[]? franchise;
        public int[]? genre;
        public int[]? ids;
        public string? kind;
        public MyList? mylist;
        public Order? order;
        public int? score;
        public string? search;
        public string? seasons;
        public string? status;
    }
}