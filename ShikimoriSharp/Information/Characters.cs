using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class Characters : ApiBase
    {
        //TODO: Ask admin for the solution of this problem (lack of documentation)
        //public async Task<Character> GetCharacterBySearchAsync() 
        public Characters(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<FullCharacter> GetCharacterById(int id)
        {
            return await Request<FullCharacter>($"characters/{id}");
        }

        public class Character
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("russian")] public string Russian { get; set; }

            [JsonProperty("image")] public Image Image { get; set; }

            [JsonProperty("url")] public string Url { get; set; }
        }

        public class FullCharacter : Character
        {
            [JsonProperty("altname")] public object Altname { get; set; }

            [JsonProperty("japanese")] public object Japanese { get; set; }

            [JsonProperty("description")] public object Description { get; set; }

            [JsonProperty("description_html")] public string DescriptionHtml { get; set; }

            [JsonProperty("description_source")] public object DescriptionSource { get; set; }

            [JsonProperty("favoured")] public bool? Favoured { get; set; }

            [JsonProperty("thread_id")] public long? ThreadId { get; set; }

            [JsonProperty("topic_id")] public long? TopicId { get; set; }

            [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

            [JsonProperty("seyu")] public Seyu[] Seyu { get; set; }

            [JsonProperty("animes")] public Anime[] Animes { get; set; }

            [JsonProperty("mangas")] public object[] Mangas { get; set; }
        }

        public class Seyu
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("russian")] public object Russian { get; set; }

            [JsonProperty("image")] public Image Image { get; set; }

            [JsonProperty("url")] public string Url { get; set; }
        }
    }
}