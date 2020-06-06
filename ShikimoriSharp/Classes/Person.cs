using System;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Classes
{
    public class SearchPerson
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("russian")] public string Russian { get; set; }
        [JsonProperty("image")] public Image Image { get; set; }
        [JsonProperty("url")] public string Url { get; set; }
    }

    public class Works
    {
        [JsonProperty("anime")] public Anime Anime { get; set; }
        [JsonProperty("manga")] public Manga Manga { get; set; }
        [JsonProperty("role")] public string Role { get; set; }
    }

    public class Person : SearchPerson
    {
        [JsonProperty("japanese")] public string Japanese { get; set; }
        [JsonProperty("job_title")] public string JobTitle { get; set; }
        [JsonProperty("birthday")] public string Birthday { get; set; }
        [JsonProperty("website")] public string Website { get; set; }
        [JsonProperty("groupped_roles")] public string[][] GrouppedRoles { get; set; }
        [JsonProperty("roles")] public object[] Roles { get; set; }
        [JsonProperty("works")] public Works[] Works { get; set; }
        [JsonProperty("thread_id")] public long ThreadId { get; set; }
        [JsonProperty("topic_id")] public long TopicId { get; set; }
        [JsonProperty("person_favoured")] public bool PersonFavoured { get; set; }
        [JsonProperty("producer")] public bool Producer { get; set; }
        [JsonProperty("producer_favoured")] public bool ProducerFavoured { get; set; }
        [JsonProperty("mangaka")] public bool Mangaka { get; set; }
        [JsonProperty("mangaka_favoured")] public bool MangakaFavoured { get; set; }
        [JsonProperty("seyu")] public bool Seyu { get; set; }
        [JsonProperty("seyu_favoured")] public bool SeyuFavoured { get; set; }
        [JsonProperty("updated_at")] public DateTimeOffset UpdatedAt { get; set; }
    }
}