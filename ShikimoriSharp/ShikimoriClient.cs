using System;
using System.Threading.Tasks;
using ShikimoriSharp.Information;

namespace ShikimoriSharp
{
    public class ShikimoriClient
    {
        public ApiClient Client { get; }

        public static async Task<ShikimoriClient> Create(string clientName, string clientId, string clientSecret,
            string authorizationCode, string redirectUrl = @"urn:ietf:wg:oauth:2.0:oob")
        {
            var obj = new ShikimoriClient(clientName, clientId, clientSecret, authorizationCode, redirectUrl);
            await obj.Client.Auth();
            return obj;
        }
        
        private ShikimoriClient(string clientName, string clientId, string clientSecret, string authorizationCode, string redirectUrl  = @"urn:ietf:wg:oauth:2.0:oob")
        {
            Client = new ApiClient(clientName, clientId, clientSecret, authorizationCode, redirectUrl);
            Animes = new Animes(Client);
        }
        public Achievements Achievements { get; set; }
        public Animes Animes { get; }
        public Appear Appear { get; set; }
        public Bans Bans { get; set; }
        public Calendars Calendars { get; set; }
        public Characters Characters { get; set; }
        public Clubs Clubs { get; set; }
        public Comments Comments { get; set; }
        public Constants Constants { get; set; }
        public Devices Devices { get; set; }
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
        
        
    }
}