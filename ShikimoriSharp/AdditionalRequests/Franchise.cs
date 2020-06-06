using Newtonsoft.Json;

namespace ShikimoriSharp.AdditionalRequests
{
    public class Franchise
    {
        [JsonProperty("links")] public Link[] Links { get; set; }

        [JsonProperty("nodes")] public Node[] Nodes { get; set; }

        [JsonProperty("current_id")] public long CurrentId { get; set; }
    }

    public class Link
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("source_id")] public long SourceId { get; set; }

        [JsonProperty("target_id")] public long TargetId { get; set; }

        [JsonProperty("source")] public long? Source { get; set; }

        [JsonProperty("target")] public long? Target { get; set; }

        [JsonProperty("weight")] public long? Weight { get; set; }

        [JsonProperty("relation")] public string Relation { get; set; }
    }

    public class Node
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("date")] public long? Date { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("image_url")] public string ImageUrl { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("year")] public object Year { get; set; }

        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("weight")] public long Weight { get; set; }
    }
}