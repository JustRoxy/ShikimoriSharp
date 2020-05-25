using System.Collections.Generic;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Settings
{
    public class StylePreviewSettings
    {
        public Dictionary<string, Dictionary<string, string>> style =
            new Dictionary<string, Dictionary<string, string>>();

        public StylePreviewSettings(string css)
        {
            style.Add("style", new Dictionary<string, string>
            {
                {"css", css}
            });
        }
    }

    public class StyleUpdateSettings
    {
        public Dictionary<string, Dictionary<string, string>> style =
            new Dictionary<string, Dictionary<string, string>>();

        public StyleUpdateSettings(string css, string name)
        {
            style.Add("style", new Dictionary<string, string>
            {
                {"css", css},
                {"name", name}
            });
        }
    }

    public class StyleSettings
    {
        public Dictionary<string, Dictionary<string, string>> style =
            new Dictionary<string, Dictionary<string, string>>();

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
    }
}