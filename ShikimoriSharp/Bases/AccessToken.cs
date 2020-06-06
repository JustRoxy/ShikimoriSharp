using Newtonsoft.Json;

namespace ShikimoriSharp.Bases
{
    public class AccessToken
    {
        [JsonProperty("access_token")] public string Access_Token { get; set; }
        [JsonProperty("token_type")] public string TokenType { get; set; } = "Bearer";

        [JsonProperty("expires_in")] public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

        [JsonProperty("scope")] public string Scope { get; set; }

        [JsonProperty("created_at")] public long CreatedAt { get; set; }
    }
}