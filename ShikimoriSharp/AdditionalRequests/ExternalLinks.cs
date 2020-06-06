using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.AdditionalRequests
{
    public class ExternalLinks
    {
        [JsonProperty("id")] public long? Id { get; set; }

        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("url")] public Uri Url { get; set; }

        [JsonProperty("source")] public string Source { get; set; }

        [JsonProperty("entry_id")] public long EntryId { get; set; }

        [JsonProperty("entry_type")] public string EntryType { get; set; }

        [JsonProperty("created_at")] public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("imported_at")] public DateTimeOffset? ImportedAt { get; set; }
    }
}