using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.AdditionalRequests;
using ShikimoriSharp.Bases;
using static ShikimoriSharp.Information.Mangas;
using static ShikimoriSharp.UpdatableInformation.Clubs;
using Version = ShikimoriSharp.Bases.Version;

namespace ShikimoriSharp.Information
{
    public class Users : ApiBase
    {
        public Users(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<User[]> GetUsers()
        {
            return await Request<User[]>("users");
        }

        public async Task<User[]> GetUsers(BasicSettings settings)
        {
            return await Request<User[], BasicSettings>("users", settings);
        }

        public async Task<UserId> GetUser(long id)
        {
            return await Request<UserId>($"users/{id}");
        }

        public async Task<UserId> GetUser(string nickname)
        {
            return await Request<UserId, UserIdRequestSettings>($"users/{nickname}", new UserIdRequestSettings(1));
        }

        public async Task<UserInfo> GetUserInfo(long id)
        {
            return await Request<UserInfo>($"users/{id}/info");
        }

        public async Task<UserInfo> WhoAmI()
        {
            return await Request<UserInfo>("users/whoami", true);
        }

        public async Task Sign_Out()
        {
            await NoResponseRequest("users/sign_out", method: "GET");
        }

        public async Task<User[]> GetFriends(long id)
        {
            return await Request<User[]>($"users/{id}/friends");
        }

        public async Task<Club[]> GetClubs(long id)
        {
            return await Request<Club[]>($"users/{id}/clubs");
        }

        public async Task<AnimeRate[]> GetUserAnimeRates(long id)
        {
            return await AllRates("anime", id);
        }

        public async Task<AnimeRate[]> GetUserAnimeRates(long id, AnimeRateRequestSettings settings)
        {
            return await AllRates("anime", id, settings);
        }

        public async Task<AnimeRate[]> GetUserMangaRates(long id)
        {
            return await AllRates("manga", id);
        }

        public async Task<AnimeRate[]> GetUserMangaRates(long id, AnimeRateRequestSettings settings)
        {
            return await AllRates("manga", id, settings);
        }

        private async Task<AnimeRate[]> AllRates(string thingy, long id)
        {
            return await Request<AnimeRate[]>($"users/{id}/{thingy}_rates");
        }

        private async Task<AnimeRate[]> AllRates(string thingy, long id, AnimeRateRequestSettings settings)
        {
            return await Request<AnimeRate[], AnimeRateRequestSettings>($"users/{id}/{thingy}_rates", settings);
        }

        public async Task<Favorites> GetFavourites(long id)
        {
            return await Request<Favorites>($"users/{id}");
        }

        public async Task<Message[]> GetMessages(long id, MessageRequestSettings settings)
        {
            return await Request<Message[], MessageRequestSettings>($"users/{id}/messages", settings, true);
        }

        public async Task<NewInformation> UnreadMessages(long id)
        {
            return await Request<NewInformation>($"users/{id}/unread_messages", true);
        }

        public async Task<History[]> GetHistory(long id)
        {
            return await Request<History[]>($"users/{id}/history");
        }

        public async Task<History[]> GetHistory(long id, HistoryRequestSettings settings)
        {
            return await Request<History[], HistoryRequestSettings>($"users/{id}/history", settings);
        }

        public async Task<Bans[]> GetBans(long id)
        {
            return await Request<Bans[]>($"users/{id}/bans");
        }

        public class History
        {
            [JsonProperty("id")] public long Id { get; set; }

            [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("description")] public string Description { get; set; }

            [JsonProperty("target")] public HistoryTarget Target { get; set; }
        }

        /// <summary>
        ///     So the point of this class is to fix the "target_type" in <see cref="HistoryRequestSettings" />
        /// </summary>
        public class HistoryTarget : Anime
        {
            [JsonProperty("volumes")] public long? Volumes { get; set; }

            [JsonProperty("chapters")] public long? Chapters { get; set; }
        }

        public class HistoryRequestSettings : BasicSettings
        {
            public string target_id;
            public string target_type;
        }

        public class NewInformation
        {
            [JsonProperty("messages")] public long Messages { get; set; }

            [JsonProperty("news")] public long News { get; set; }

            [JsonProperty("notifications")] public long Notifications { get; set; }
        }

        public class MessageRequestSettings : BasicSettings
        {
            public string type;
            /// <summary>
            /// Must be one of: inbox, private, sent, news, notifications
            /// </summary>
            public MessageRequestSettings(string type = "sent")
            {
                this.type = type;
            }
        }
        public class AnimeRateRequestSettings : BasicSettings
        {
            public bool? censored;
        }

        public class Favorites
        {
            [JsonProperty("animes")] public SmallRepresentation[] Animes { get; set; }

            [JsonProperty("mangas")] public SmallRepresentation[] Mangas { get; set; }

            [JsonProperty("characters")] public SmallRepresentation[] Characters { get; set; }

            [JsonProperty("people")] public SmallRepresentation[] People { get; set; }

            [JsonProperty("mangakas")] public SmallRepresentation[] Mangakas { get; set; }

            [JsonProperty("seyu")] public SmallRepresentation[] Seyu { get; set; }

            [JsonProperty("producers")] public SmallRepresentation[] Producers { get; set; }
        }

        private class UserIdRequestSettings
        {
            /// <summary>
            ///     1 if you want to get user by its nickname
            /// </summary>
            public int is_nickname;

            public UserIdRequestSettings(int isNickname)
            {
                is_nickname = isNickname;
            }
        }

        public class AnimeRate
        {
            [JsonProperty("id")] public long Id { get; set; }

            [JsonProperty("score")] public long Score { get; set; }

            [JsonProperty("status")] public string Status { get; set; }

            [JsonProperty("text")] public object Text { get; set; }

            [JsonProperty("episodes")] public long? Episodes { get; set; }

            [JsonProperty("chapters")] public long? Chapters { get; set; }

            [JsonProperty("volumes")] public long? Volumes { get; set; }

            [JsonProperty("text_html")] public object TextHtml { get; set; }

            [JsonProperty("rewatches")] public long? Rewatches { get; set; }

            [JsonProperty("created_at")] public DateTimeOffset? CreatedAt { get; set; }

            [JsonProperty("updated_at")] public DateTimeOffset? UpdatedAt { get; set; }

            [JsonProperty("user")] public User User { get; set; }

            [JsonProperty("anime")] public Anime Anime { get; set; }

            [JsonProperty("manga")] public Manga Manga { get; set; }
        }

        public class User
        {
            [JsonProperty("id")] public long Id { get; set; }
            [JsonProperty("nickname")] public string Nickname { get; set; }

            [JsonProperty("avatar")] public Uri Avatar { get; set; }

            [JsonProperty("image")] public PureImage Image { get; set; }

            [JsonProperty("last_online_at")] public DateTimeOffset LastOnlineAt { get; set; }
        }

        public class MessageContent
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("kind")] public string Kind { get; set; }

            [JsonProperty("read")] public bool? Read { get; set; }

            [JsonProperty("body")] public string Body { get; set; }

            [JsonProperty("html_body")] public string HtmlBody { get; set; }

            [JsonProperty("created_at")] public DateTimeOffset CreatedAt { get; set; }

            [JsonProperty("linked_id")] public long? LinkedId { get; set; }

            [JsonProperty("linked_type")] public string LinkedType { get; set; }

            [JsonProperty("linked")] public UserLinked Linked { get; set; }
        }

        public class Message : MessageContent
        {
            [JsonProperty("from")] public User From { get; set; }
            [JsonProperty("to")] public User To { get; set; }
        }

        public class UserLinked : Linked
        {
            [JsonProperty("topic_url")] public Uri TopicUrl { get; set; }

            [JsonProperty("thread_id")] public long ThreadId { get; set; }

            [JsonProperty("topic_id")] public long TopicId { get; set; }

            [JsonProperty("type")] public string Type { get; set; }
        }

        public class BasicUser : User
        {
            [JsonProperty("name")] public object Name { get; set; }

            [JsonProperty("sex")] public object Sex { get; set; }

            [JsonProperty("website")] public object Website { get; set; }

            [JsonProperty("locale")] public string Locale { get; set; }
        }

        public class UserInfo : BasicUser
        {
            [JsonProperty("birth_on")] public object BirthOn { get; set; }
        }

        public class UserId : BasicUser
        {
            [JsonProperty("full_years")] public long? FullYears { get; set; }

            [JsonProperty("last_online")] public string LastOnline { get; set; }

            [JsonProperty("location")] public string Location { get; set; }

            [JsonProperty("banned")] public bool? Banned { get; set; }

            [JsonProperty("about")] public object About { get; set; }

            [JsonProperty("about_html")] public string AboutHtml { get; set; }

            [JsonProperty("common_info")] public string[] CommonInfo { get; set; }

            [JsonProperty("show_comments")] public bool? ShowComments { get; set; }

            [JsonProperty("in_friends")] public bool? InFriends { get; set; }

            [JsonProperty("is_ignored")] public bool? IsIgnored { get; set; }

            [JsonProperty("stats")] public Stats Stats { get; set; }

            [JsonProperty("style_id")] public long? StyleId { get; set; }
        }


        public class Stats
        {
            [JsonProperty("statuses")] public Statuses Statuses { get; set; }

            [JsonProperty("full_statuses")] public Statuses FullStatuses { get; set; }

            [JsonProperty("scores")] public Scores Scores { get; set; }

            [JsonProperty("types")] public Scores Types { get; set; }

            [JsonProperty("ratings")] public Ratings Ratings { get; set; }

            [JsonProperty("has_anime?")] public bool? HasAnime { get; set; }

            [JsonProperty("has_manga?")] public bool? HasManga { get; set; }

            [JsonProperty("genres")] public object[] Genres { get; set; }

            [JsonProperty("studios")] public object[] Studios { get; set; }

            [JsonProperty("publishers")] public object[] Publishers { get; set; }

            [JsonProperty("activity")] public Activity[] Activity { get; set; }
        }

        public class Activity
        {
            [JsonProperty("name")] public long[] Name { get; set; }

            [JsonProperty("value")] public long? Value { get; set; }
        }

        public class Statuses
        {
            [JsonProperty("anime")] public FullStatusesAnime[] Anime { get; set; }

            [JsonProperty("manga")] public FullStatusesAnime[] Manga { get; set; }
        }

        public class FullStatusesAnime
        {
            [JsonProperty("id")] public long? Id { get; set; }

            [JsonProperty("grouped_id")] public string GroupedId { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("size")] public long? Size { get; set; }

            [JsonProperty("type")] public string Type { get; set; }
        }

        public class Ratings
        {
            [JsonProperty("anime")] public RatingsAnime[] Anime { get; set; }
        }

        public class RatingsAnime
        {
            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("value")] public long? Value { get; set; }
        }

        public class Scores
        {
            [JsonProperty("anime")] public RatingsAnime[] Anime { get; set; }

            [JsonProperty("manga")] public RatingsAnime[] Manga { get; set; }
        }
    }
}