using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;
using ShikimoriSharp.UpdatableInformation;

namespace ShikimoriSharp
{
    public class ShikimoriClient
    {
        public ShikimoriClient(ILogger logger, ClientSettings settings)
        {
            Client = new ApiClient(logger, settings);
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
        public Achievements Achievements { get; }
        public Animes Animes { get; }
        public Bans Bans { get; }
        public Calendars Calendars { get; }
        public Characters Characters { get; }
        public Clubs Clubs { get; }
        public Comments Comments { get; }
        public Constants Constants { get; }
        public Dialogs Dialogs { get; }
        public Favorites Favorites { get; }
        public Forums Forums { get; }
        public Friends Friends { get; }
        public Genres Genres { get; }
        public Mangas Mangas { get; }
        public Messages Messages { get; }
        public People People { get; }
        public Publishers Publishers { get; }
        public Ranobe Ranobe { get; }
        public Stats Stats { get; }
        public Studios Studios { get; }
        public Styles Styles { get; }
        public TopicIgnores TopicIgnores { get; }
        public Topics Topics { get; }
        public UserImages UserImages { get; }
        public UserRates UserRates { get; }
        public Users Users { get; }
        public Videos Videos { get; }
    }
}