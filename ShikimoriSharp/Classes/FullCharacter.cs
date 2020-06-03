using System;
using Newtonsoft.Json;

namespace ShikimoriSharp.Classes
{
    public class FullCharacter : Character
    {
        [JsonProperty("altname")] public string Altname { get; set; }
        [JsonProperty("japanese")] public string Japanese { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("description_html")] public string DescriptionHtml { get; set; }
        [JsonProperty("description_source")] public string DescriptionSource { get; set; }
        [JsonProperty("favoured")] public bool Favoured { get; set; }
        [JsonProperty("thread_id")] public long? ThreadId { get; set; }
        [JsonProperty("topic_id")] public long? TopicId { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("seyu")] public Seyu[] Seyu { get; set; }
        [JsonProperty("animes")] public Anime[] Animes { get; set; }
        [JsonProperty("mangas")] public Manga[] Mangas { get; set; }
    }
}