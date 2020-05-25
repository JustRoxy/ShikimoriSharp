#nullable enable
namespace ShikimoriSharp.Settings
{
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