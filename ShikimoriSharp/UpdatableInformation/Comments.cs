using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Comments : ApiBase
    {
        public Comments(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Comment> GetComment(int id)
        {
            return await Request<Comment>($"comments/{id}", true);
        }

        public async Task<Comment> GetComments(CommentsRequestSettings settings)
        {
            return await Request<Comment, CommentsRequestSettings>("comments", settings, true);
        }

        public async Task<Comment> SendComment(CommentCreateSettings settings)
        {
            return await SendJson<Comment>("comments", settings, true);
        }

        public async Task<Comment> EditComment(int id, CommentEditSettings newMessage)
        {
            return await SendJson<Comment>($"comments/{id}", newMessage, true, "PUT");
        }

        public async Task DeleteComment(int id)
        {
            await NoResponseRequest($"comment/{id}", true, "DELETE");
        }

        public class CommentEditSettings
        {
            [JsonProperty("comment")] public CommentEditContent Content;
            public bool frontend;

            public CommentEditSettings(CommentEditContent content)
            {
                Content = content;
            }
        }

        public class CommentEditContent
        {
            public string body;

            public CommentEditContent(string body)
            {
                this.body = body;
            }
        }

        public class CommentCreateSettings
        {
            [JsonProperty("comment")] public CommentCreateContent Content;

            public CommentCreateSettings(CommentCreateContent content)
            {
                Content = content;
            }
        }

        public class CommentCreateContent
        {
            public string? body;
            public bool? broadcast;
            public int? commentable_id;
            public string? commentable_type;
            public bool? frontend;
            public bool? is_offtopic;
            public bool? is_summary;

            public CommentCreateContent(string body, int commentableId, string commentableType)
            {
                this.body = body;
                commentable_id = commentableId;
                commentable_type = commentableType;
            }
        }

        public class CommentsRequestSettings : BasicSettings
        {
            public int? commentable_id;
            public string? commentable_type;
            public byte? desc;
            public bool? is_summary;

            public CommentsRequestSettings(int commentableId, string commentableType)
            {
                commentable_id = commentableId;
                commentable_type = commentableType;
            }
        }

        public class Comment
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("user_id")] public long? UserIdUserId { get; set; }

            [JsonProperty("commentable_id")] public long? CommentableId { get; set; }

            [JsonProperty("commentable_type")] public string CommentableType { get; set; }

            [JsonProperty("body")] public string Body { get; set; }

            [JsonProperty("html_body")] public string HtmlBody { get; set; }

            [JsonProperty("created_at")] public DateTimeOffset? CreatedAt { get; set; }

            [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

            [JsonProperty("is_offtopic")] public bool? IsOfftopic { get; set; }

            [JsonProperty("is_summary")] public bool? IsSummary { get; set; }

            [JsonProperty("can_be_edited")] public bool? CanBeEdited { get; set; }

            [JsonProperty("user")] public Users.User User { get; set; }
        }
    }
}