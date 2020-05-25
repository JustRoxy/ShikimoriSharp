#nullable enable
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Settings
{
    public class AnimeRequestSettings : MangaAnimeRequestSettingsBase
    {
        public Duration? duration;
        public int[]? studio;
    }
}