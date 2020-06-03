using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Classes
{
    public class NewVideo
    {
        private readonly Dictionary<string, Dictionary<string, string>> video =
            new Dictionary<string, Dictionary<string, string>>();

        public NewVideo(VideoKind kind, string name, string url)
        {
            video.Add("video", new Dictionary<string, string>
            {
                {"kind", kind.ToString()},
                {"name", name},
                {"url", url}
            });
        }
    }

    public class Video
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("url")] public Uri Url { get; set; }
        [JsonProperty("image_url")] public Uri ImageUrl { get; set; }
        [JsonProperty("player_url")] public Uri PlayerUrl { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("hosting")] public string Hosting { get; set; }
    }
}