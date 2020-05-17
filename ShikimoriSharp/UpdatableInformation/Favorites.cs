using System;
using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Favorites : ApiBase
    {
        public Favorites(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task PostFavorite(FavoriteSettings s)
        {
            if (s.linked_type.ToLower() == "person" && s.kind is null)
                throw new Exception("Kind can not be null, when linked_id is Person");

            await NoResponseRequest($"favorites/{s.linked_type}/{s.linked_id}/{s.kind}");
        }

        public async Task DeleteFavorite(FavoriteSettings s)
        {
            await NoResponseRequest($"favorites/{s.linked_type}/{s.linked_id}", method: "DELETE");
        }

        public async Task ReorderFavorite(int id, Position pos = null)
        {
            await NoResponseRequest($"favorites/{id}/reorder", pos);
        }

        public class Position
        {
            public int new_index;
        }

        public class FavoriteSettings
        {
            public string? kind;
            public int? linked_id;
            public string? linked_type;

            public FavoriteSettings(int linkedId, string linkedType)
            {
                linked_id = linkedId;
                linked_type = linkedType;
            }
        }
    }
}