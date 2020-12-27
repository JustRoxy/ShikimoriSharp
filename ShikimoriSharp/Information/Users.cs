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

        public async Task<UserId> GetUser(long id, AccessToken personalInformation = null)
        {
            return await Request<UserId>($"users/{id}", personalInformation);
        }

        public async Task<UserId> GetUser(string nickname, AccessToken personalInformation = null)
        {
            return await Request<UserId, UserIdRequestSettings>($"users/{nickname}", new UserIdRequestSettings(1),
                personalInformation);
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

        public async Task<User[]> GetFriends(long id, AccessToken personalInformation = null)
        {
            return await Request<User[]>($"users/{id}/friends", personalInformation);
        }

        public async Task<Club[]> GetClubs(long id, AccessToken personalInformation = null)
        {
            return await Request<Club[]>($"users/{id}/clubs", personalInformation);
        }

        public async Task<AnimeRate[]> GetUserAnimeRates(long id, AccessToken personalInformation = null)
        {
            return await AllRates("anime", id, personalInformation);
        }

        public async Task<AnimeRate[]> GetUserAnimeRates(long id, AnimeRateRequestSettings settings, AccessToken personalInformation = null)
        {
            return await AllRates("anime", id, settings, personalInformation);
        }

        public async Task<AnimeRate[]> GetUserMangaRates(long id, AccessToken personalInformation = null)
        {
            return await AllRates("manga", id, personalInformation);
        }

        public async Task<AnimeRate[]> GetUserMangaRates(long id, AnimeRateRequestSettings settings, AccessToken personalInformation = null)
        {
            return await AllRates("manga", id, settings, personalInformation);
        }

        private async Task<AnimeRate[]> AllRates(string thingy, long id, AccessToken p)
        {
            return await Request<AnimeRate[]>($"users/{id}/{thingy}_rates", p);
        }

        private async Task<AnimeRate[]> AllRates(string thingy, long id, AnimeRateRequestSettings settings, AccessToken p)
        {
            return await Request<AnimeRate[], AnimeRateRequestSettings>($"users/{id}/{thingy}_rates", settings, p);
        }

        public async Task<Favorites> GetFavourites(long id)
        {
            return await Request<Favorites>($"users/{id}/favourites");
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