#nullable enable
using Newtonsoft.Json;
using ShikimoriSharp.Enums;

namespace ShikimoriSharp.Settings
{
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
        public long commentable_id;
        public string? commentable_type;
        public bool? frontend;
        public bool? is_offtopic;
        public bool? is_summary;

        /// <summary>
        ///     commentableType can be Topic, User, Anime, Manga, Character, Person
        /// </summary>
        /// <param name="body"></param>
        /// <param name="commentableId"></param>
        /// <param name="commentableType"></param>
        public CommentCreateContent(string body, long commentableId, string commentableType)
        {
            this.body = body;
            commentable_id = commentableId;
            commentable_type = commentableType;
        }
    }

    public class CommentsRequestSettings : BasicSettings
    {
        public long commentable_id;
        public CommentableType commentable_type;
        public byte? desc;
        public bool? is_summary;

        public CommentsRequestSettings(long commentableId, CommentableType commentableType)
        {
            commentable_id = commentableId;
            commentable_type = commentableType;
        }
    }
}