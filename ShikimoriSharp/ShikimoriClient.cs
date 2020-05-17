using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;
using ShikimoriSharp.UpdatableInformation;

namespace ShikimoriSharp
{
    public class ShikimoriClient
    {
        private ShikimoriClient(string clientName, string clientId, string clientSecret,
            string redirectUrl = @"urn:ietf:wg:oauth:2.0:oob")
        {
            Client = new ApiClient(clientName, clientId, clientSecret, redirectUrl);
            Achievements = new Achievements(Client);
            Animes = new Animes(Client);
            Bans = new Bans(Client);
            Calendars = new Calendars(Client);
            Characters = new Characters(Client);
            Clubs = new Clubs(Client);
            Comments = new Comments(Client);
            Constants = new Constants(Client);
            Dialogs = new Dialogs(Client);
            Favorites = new Favorites(Client);
            Forums = new Forums(Client);
            Friends = new Friends(Client);
            Genres = new Genres(Client);
            Mangas = new Mangas(Client);
            Messages = new Messages(Client);
            People = new People(Client);
            Publishers = new Publishers(Client);
            Ranobe = new Ranobe(Client);
            Stats = new Stats(Client);
            Studios = new Studios(Client);
            Styles = new Styles(Client);
            TopicIgnores = new TopicIgnores(Client);
            Topics = new Topics(Client);
            UserImages = new UserImages(Client);
            UserRates = new UserRates(Client);
            Users = new Users(Client);
            Videos = new Videos(Client);
        }

        public ApiClient Client { get; }
        public Achievements Achievements { get; set; }
        public Animes Animes { get; }
        public Bans Bans { get; set; }
        public Calendars Calendars { get; set; }
        public Characters Characters { get; set; }
        public Clubs Clubs { get; set; }
        public Comments Comments { get; set; }
        public Constants Constants { get; set; }
        public Dialogs Dialogs { get; set; }
        public Favorites Favorites { get; set; }
        public Forums Forums { get; set; }
        public Friends Friends { get; set; }
        public Genres Genres { get; set; }
        public Mangas Mangas { get; set; }
        public Messages Messages { get; set; }
        public People People { get; set; }
        public Publishers Publishers { get; set; }
        public Ranobe Ranobe { get; set; }
        public Stats Stats { get; set; }
        public Studios Studios { get; set; }
        public Styles Styles { get; set; }
        public TopicIgnores TopicIgnores { get; set; }
        public Topics Topics { get; set; }
        public UserImages UserImages { get; set; }
        public UserRates UserRates { get; set; }
        public Users Users { get; set; }
        public Videos Videos { get; set; }

        public static async Task<ShikimoriClient> Create(string clientName, string clientId, string clientSecret,
            string authorizationCode, string redirectUrl = @"urn:ietf:wg:oauth:2.0:oob")
        {
            var obj = new ShikimoriClient(clientName, clientId, clientSecret, redirectUrl);
            await obj.Client.Auth(authorizationCode);
            return obj;
        }

        public static ShikimoriClient Create(string clientName, string clientId, string clientSecret,
            AccessToken token, string redirectUrl = @"urn:ietf:wg:oauth:2.0:oob")
        {
            var obj = new ShikimoriClient(clientName, clientId, clientSecret, redirectUrl);
            obj.Client.Auth(token);
            return obj;
        }
    }
}