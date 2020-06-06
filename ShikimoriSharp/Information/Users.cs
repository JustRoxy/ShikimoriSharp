using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;
using ShikimoriSharp.Settings;

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

        public async Task<UserInfo> WhoAmI(AccessToken personalInformation)
        {
            return await Request<UserInfo>("users/whoami", personalInformation);
        }

        public async Task Sign_Out(AccessToken personalInformation)
        {
            await NoResponseRequest("users/sign_out", personalInformation, method: "GET");
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

        public async Task<Message[]> GetMessages(long id, MessageRequestSettings settings, AccessToken personalInformation)
        {
            return await Request<Message[], MessageRequestSettings>($"users/{id}/messages", settings, personalInformation);
        }

        public async Task<NewInformation> UnreadMessages(long id, AccessToken personalInformation)
        {
            return await Request<NewInformation>($"users/{id}/unread_messages", personalInformation);
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
    }
}