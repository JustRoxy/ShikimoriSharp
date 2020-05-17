using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Videos : ApiBase
    {
        public async Task<Video> GetVideos(int id)
        {
            return await Request<Video>($"animes/{id}/videos");
        }

        public async Task<Video> PostVideo(int id, NewVideo video)
        {
            return await SendJson<Video>($"animes/{id}/videos", video, true);
        }

        public async Task DeleteVideo(int a_id, int id)
        {
            await NoResponseRequest($"animes/{a_id}/videos/{id}");
        }

        public class NewVideo
        {
            public NewVideo(VideoKind kind, string name, string url)
            {
                video.Add("video", new Dictionary<string, string>
                {
                    {"kind", kind.ToString()},
                    {"name", name},
                    {"url", url}
                });
            }
            Dictionary<string, Dictionary<string, string>> video = new Dictionary<string, Dictionary<string, string>>();
        }
        public enum VideoKind
        {
            pv, character_trailer, clip, cm, other, op_clip, ed_clip, op, ed, episode_preview
        }
        
        public class Video
        {
            [JsonProperty("id")]
            public long? Id { get; set; }

            [JsonProperty("url")]
            public Uri Url { get; set; }

            [JsonProperty("image_url")]
            public Uri ImageUrl { get; set; }

            [JsonProperty("player_url")]
            public Uri PlayerUrl { get; set; }

            [JsonProperty("name")]
            public object Name { get; set; }

            [JsonProperty("kind")]
            public string Kind { get; set; }

            [JsonProperty("hosting")]
            public string Hosting { get; set; }
        }

        public Videos(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }
    }
}