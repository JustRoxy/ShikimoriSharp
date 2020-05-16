using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class Bans : ApiBase
    {
        public Bans(ApiClient apiClient) : base(Version.v1, apiClient)
        {}

        public async Task<Ban[]> GetBansAsync()
        {
            return await Request<Ban[]>("bans");
        }
        public partial class Ban
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("moderator_id")]
        public long ModeratorId { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("duration_minutes")]
        public long DurationMinutes { get; set; }

        [JsonProperty("user")]
        public Moderator User { get; set; }

        [JsonProperty("moderator")]
        public Moderator Moderator { get; set; }
    }

    public partial class Comment
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("commentable_id")]
        public long CommentableId { get; set; }

        [JsonProperty("commentable_type")]
        public string CommentableType { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("is_summary")]
        public bool IsSummary { get; set; }

        [JsonProperty("is_offtopic")]
        public bool IsOfftopic { get; set; }
    }

    public partial class Moderator
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }

        [JsonProperty("avatar")]
        public Uri Avatar { get; set; }

        [JsonProperty("image")]
        public PureImage Image { get; set; }

        [JsonProperty("last_online_at")]
        public DateTimeOffset LastOnlineAt { get; set; }
    }

    
    }
}