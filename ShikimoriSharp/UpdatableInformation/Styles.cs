using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Styles : ApiBase
    {
        public Styles(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Style> GetStyle(int id)
        {
            return await Request<Style>($"styles/{id}");
        }

        public async Task<Style> PreviewStyle(StylePreviewSettings settings, AccessToken personalInformation = null)
        {
            return await SendJson<Style>("styles/preview", settings.style, personalInformation);
        }

        public async Task<Style> CreateStyle(StyleSettings settings, AccessToken personalInformation)
        {
            return await SendJson<Style>("styles/preview", settings.style, personalInformation);
        }

        public async Task<Style> UpdateStyle(int id, StyleUpdateSettings settings, AccessToken personalInformation)
        {
            return await SendJson<Style>($"styles/{id}", settings.style, personalInformation);
        }
    }
}