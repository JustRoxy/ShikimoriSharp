using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Bases
{
    public class SmallRepresentation
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("russian")] public string Russian { get; set; }
        [JsonProperty("image")] public Image Image { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }

    public class AnimeMangaBase : SmallRepresentation
    {
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("score")] public string Score { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("aired_on")] public DateTimeOffset? AiredOn { get; set; }
        [JsonProperty("released_on")] public DateTimeOffset? ReleasedOn { get; set; }
    }
}