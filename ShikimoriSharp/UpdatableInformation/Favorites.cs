using System;
using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Settings;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Favorites : ApiBase
    {
        public Favorites(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task PostFavorite(FavoriteSettings s, AccessToken personalInformation)
        {
            if (s.linked_type != null && s.linked_type.ToLower() == "person" && s.kind is null)
                throw new Exception("Kind can not be null, when linked_id is Person");

            await NoResponseRequest($"favorites/{s.linked_type}/{s.linked_id}/{s.kind}", personalInformation);
        }

        public async Task DeleteFavorite(FavoriteSettings s, AccessToken personalInformation)
        {
            await NoResponseRequest($"favorites/{s.linked_type}/{s.linked_id}", personalInformation, method: "DELETE");
        }

        public async Task ReorderFavorite(int id, AccessToken personalInformation, Position pos = null)
        {
            await NoResponseRequest($"favorites/{id}/reorder", pos, personalInformation);
        }
    }
}