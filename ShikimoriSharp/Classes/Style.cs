using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class Style
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("owner_id")] public long OwnerId { get; set; }
        [JsonProperty("owner_type")] public string OwnerType { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("css")] public string Css { get; set; }
        [JsonProperty("compiled_css")] public string CompiledCss { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset? CreatedAt { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }
    }
}