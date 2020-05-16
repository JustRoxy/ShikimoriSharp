using Newtonsoft.Json;
using ShikimoriSharp.Information;

namespace ShikimoriSharp.AdditionalRequests
{
    public class Role
    {
        [JsonProperty("roles")] public string[] Roles { get; set; }

        [JsonProperty("roles_russian")] public string[] RolesRussian { get; set; }

        [JsonProperty("character")] public Characters.Character Character { get; set; }

        [JsonProperty("person")] public Characters.Character Person { get; set; }
    }
}