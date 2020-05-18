﻿using Newtonsoft.Json;
using static ShikimoriSharp.Information.Characters;

namespace ShikimoriSharp.AdditionalRequests
{
    public class Role
    {
        [JsonProperty("roles")] public string[] Roles { get; set; }

        [JsonProperty("roles_russian")] public string[] RolesRussian { get; set; }

        [JsonProperty("character")] public Character Character { get; set; }

        [JsonProperty("person")] public Character Person { get; set; }
    }
}