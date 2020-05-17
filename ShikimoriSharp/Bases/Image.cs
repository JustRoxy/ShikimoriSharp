using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Bases
{
    public class Image
    {
        [JsonProperty("original")] public string Original { get; set; }

        [JsonProperty("preview")] public string Preview { get; set; }

        [JsonProperty("x96")] public string X96 { get; set; }

        [JsonProperty("x48")] public string X48 { get; set; }
    }

    public class PureImage
    {
        [JsonProperty("x160")] public Uri X160 { get; set; }

        [JsonProperty("x148")] public Uri X148 { get; set; }

        [JsonProperty("x80")] public Uri X80 { get; set; }

        [JsonProperty("x64")] public Uri X64 { get; set; }

        [JsonProperty("x48")] public Uri X48 { get; set; }

        [JsonProperty("x32")] public Uri X32 { get; set; }

        [JsonProperty("x16")] public Uri X16 { get; set; }
    }
}