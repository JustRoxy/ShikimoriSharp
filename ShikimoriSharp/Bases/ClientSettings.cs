namespace ShikimoriSharp.Bases
{
    public class ClientSettings
    {
        public ClientSettings(string clientName, string clientId, string clientSecret, string redirectUrl = @"urn:ietf:wg:oauth:2.0:oob")
        {
            ClientName = clientName;
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUrl = redirectUrl;
        }

        public string ClientName { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string RedirectUrl { get; }

    }
}