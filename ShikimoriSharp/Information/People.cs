using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class People : ApiBase
    {
        public async Task<Person> GetPerson(int id)
            => await Request<Person>($"people/{id}");
        //TODO: Contact admin (lack of documentation)
        //public async Task<Person> GetPersonBySearch(??? settings)
        //    => await Request<Person, ???>($"people/search", settings);
        public People(ApiClient apiClient) : base(Version.v1, apiClient)
        {}

        public class Person
        {
            [JsonProperty("id")]
                public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("russian")]
            public object Russian { get; set; }

            [JsonProperty("image")]
            public Image Image { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }

            [JsonProperty("japanese")]
            public object Japanese { get; set; }

            [JsonProperty("job_title")]
            public string JobTitle { get; set; }

            [JsonProperty("birthday")]
            public object Birthday { get; set; }

            [JsonProperty("website")]
            public object Website { get; set; }

            [JsonProperty("groupped_roles")]
            public object[] GrouppedRoles { get; set; }

            [JsonProperty("roles")]
            public object[] Roles { get; set; }

            [JsonProperty("works")]
            public object[] Works { get; set; }

            [JsonProperty("thread_id")]
            public object ThreadId { get; set; }

            [JsonProperty("topic_id")]
            public object TopicId { get; set; }

            [JsonProperty("person_favoured")]
            public bool PersonFavoured { get; set; }

            [JsonProperty("producer")]
            public bool Producer { get; set; }

            [JsonProperty("producer_favoured")]
            public bool ProducerFavoured { get; set; }

            [JsonProperty("mangaka")]
            public bool Mangaka { get; set; }

            [JsonProperty("mangaka_favoured")]
            public bool MangakaFavoured { get; set; }

            [JsonProperty("seyu")]
            public bool Seyu { get; set; }

            [JsonProperty("seyu_favoured")]
            public bool SeyuFavoured { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset UpdatedAt { get; set; }
        }
    }
}