using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Styles : ApiBase
    {
        public async Task<Style> GetStyle(int id)
        {
            return await Request<Style>($"styles/{id}");
        }

        public async Task<Style> PreviewStyle(StylePreviewSettings settings)
        {
            return await SendJson<Style>($"styles/preview", settings.style, true);
        }

        public async Task<Style> CreateStyle(StyleSettings settings)
        {
            return await SendJson<Style>("styles/preview", settings.style, true);
        }

        public async Task<Style> UpdateStyle(int id, StyleUpdateSettings settings)
        {
            return await SendJson<Style>($"styles/{id}", settings.style, true);
        }

        public class StylePreviewSettings
        {
            public StylePreviewSettings(string css)
            {
                style.Add("style", new Dictionary<string, string>
                {
                    {"css", css}
                });
            }
            public Dictionary<string, Dictionary<string, string>> style = new Dictionary<string, Dictionary<string, string>>();
        }
        public class StyleUpdateSettings
        {
            public StyleUpdateSettings(string css, string name)
            {
                style.Add("style", new Dictionary<string, string>
                {
                    {"css", css},
                    {"name", name},
                });
            }
            public Dictionary<string, Dictionary<string, string>> style = new Dictionary<string, Dictionary<string, string>>();
        }
        public class StyleSettings
        {
            public StyleSettings(string css, string name, int owner_id, OwnerType owner_type)
            {
                style.Add("style", new Dictionary<string, string>
                {
                    {"css", css},
                    {"name", name},
                    {"owner_id", owner_id.ToString()},
                    {"owner_type", owner_type.ToString()}
                });
            }
            public Dictionary<string, Dictionary<string, string>> style = new Dictionary<string, Dictionary<string, string>>();
        }

        public enum OwnerType
        {
            User,
            Club
        }
        public class Style
        {
            [JsonProperty("id")]
            public long? Id { get; set; }

            [JsonProperty("owner_id")]
            public long? OwnerId { get; set; }

            [JsonProperty("owner_type")]
            public string OwnerType { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("css")]
            public string Css { get; set; }

            [JsonProperty("compiled_css")]
            public object CompiledCss { get; set; }

            [JsonProperty("created_at")]
            public DateTimeOffset? CreatedAt { get; set; }

            [JsonProperty("updated_at")]
            public DateTimeOffset? UpdatedAt { get; set; }
        }

        public Styles(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }
    }
}