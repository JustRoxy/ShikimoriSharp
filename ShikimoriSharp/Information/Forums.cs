﻿using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;

namespace ShikimoriSharp.Information
{
    public class Forums : ApiBase
    {
        public Forums(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Forum[]> GetForums()
        {
            return await Request<Forum[]>("forums");
        }

        public class Forum
        {
            [JsonProperty("id")] public long Id { get; set; }

            [JsonProperty("position")] public long Position { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("permalink")] public string Permalink { get; set; }

            [JsonProperty("url")] public string Url { get; set; }
        }
    }
}