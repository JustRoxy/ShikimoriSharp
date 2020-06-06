using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class MessageContent
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("kind")] public string Kind { get; set; }
        [JsonProperty("read")] public bool Read { get; set; }
        [JsonProperty("body")] public string Body { get; set; }
        [JsonProperty("html_body")] public string HtmlBody { get; set; }
        [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }
        [JsonProperty("linked_id")] public long LinkedId { get; set; }
        [JsonProperty("linked_type")] public string LinkedType { get; set; }
        [JsonProperty("linked")] public UserLinked Linked { get; set; }
    }

    public class Message : MessageContent
    {
        [JsonProperty("from")] public User From { get; set; }
        [JsonProperty("to")] public User To { get; set; }
    }
}