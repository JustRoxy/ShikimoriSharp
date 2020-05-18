﻿#nullable enable
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Mangas : ApiBase
    {
        public Mangas(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Manga[]> GetManga()
        {
            return await Request<Manga[]>("mangas");
        }

        public async Task<Manga[]> GetManga(MangaRequestSettings settings)
        {
            return await Request<Manga[], MangaRequestSettings>("mangas", settings);
        }

        public async Task<MangaID> GetManga(long id)
        {
            return await Request<MangaID>($"mangas/{id}");
        }

        public async Task<Role[]> GetRoles(long id)
        {
            return await Request<Role[]>($"mangas/{id}/roles");
        }

        public async Task<Manga[]> GetSimilar(long id)
        {
            return await Request<Manga[]>($"mangas/{id}/similar");
        }

        public async Task<Related[]> GetRelated(long id)
        {
            return await Request<Related[]>($"mangas/{id}/related");
        }

        public async Task<Franchise> GetFranchise(long id)
        {
            return await Request<Franchise>($"mangas/{id}/franchise");
        }

        public async Task<ExternalLinks[]> GetExternalLinks(long id)
        {
            return await Request<ExternalLinks[]>($"mangas/{id}/external_links");
        }

        public async Task<Topic[]> GetTopics(long id)
        {
            return await Request<Topic[]>($"mangas/{id}/topics");
        }

        public async Task<Topic[]> GetTopics(long id, BasicSettings settings)
        {
            return await Request<Topic[], BasicSettings>($"mangas/{id}/topics", settings);
        }


        public class MangaID : AnimeMangaIdBase
        {
            [JsonProperty("volumes")] public long? Volumes { get; set; }
            [JsonProperty("chapters")] public long? Chapters { get; set; }
            [JsonProperty("publishers")] public Publishers.Publisher[] Publishers { get; set; }
        }

        public class Manga : AnimeMangaBase
        {
            [JsonProperty("volumes")] public long? Volumes { get; set; }

            [JsonProperty("chapters")] public long? Chapters { get; set; }
        }

        public class MangaRequestSettings : MangaAnimeRequestSettingsBase
        {
            public int[]? publisher;
        }
    }
}