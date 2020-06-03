using Newtonsoft.Json;
using ShikimoriSharp.Classes;

namespace ShikimoriSharp.Bases
{
    public class AnimeMangaIdBase : AnimeMangaBase
    {
        [JsonProperty("english")] public string[] English { get; set; }

        [JsonProperty("japanese")] public string[] Japanese { get; set; }

        [JsonProperty("synonyms")] public string[] Synonyms { get; set; }

        [JsonProperty("license_name_ru")] public string LicenseNameRu { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("description_html")] public string DescriptionHtml { get; set; }

        [JsonProperty("description_source")] public string DescriptionSource { get; set; }
        [JsonProperty("franchise")] public string Franchise { get; set; }

        [JsonProperty("favoured")] public bool Favoured { get; set; }

        [JsonProperty("anons")] public bool Anons { get; set; }

        [JsonProperty("ongoing")] public bool Ongoing { get; set; }

        [JsonProperty("thread_id")] public long? ThreadId { get; set; }

        [JsonProperty("topic_id")] public long? TopicId { get; set; }

        [JsonProperty("myanimelist_id")] public long? MyanimelistId { get; set; }

        [JsonProperty("rates_scores_stats")] public Rate[] RatesScoresStats { get; set; }

        [JsonProperty("rates_statuses_stats")] public Rate[] RatesStatusesStats { get; set; }

        [JsonProperty("genres")] public Genre[] Genres { get; set; }

        [JsonProperty("user_rate")] public PublicUserRate UserRate { get; set; }
    }

    public class Rate
    {
        [JsonProperty("name")] public string Name;

        [JsonProperty("value")] public long? Value;
    }
}