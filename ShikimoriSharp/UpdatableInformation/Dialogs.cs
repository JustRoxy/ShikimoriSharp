using System.Threading.Tasks;
using Newtonsoft.Json;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Information;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Dialogs : ApiBase
    {
        public Dialogs(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Dialog[]> GetDialogs()
        {
            return await Request<Dialog[]>("dialogs", true);
        }

        public async Task<Users.Message[]> GetDialogs(string fromNickname)
        {
            return await Request<Users.Message[]>($"dialogs/{fromNickname}", true);
        }

        public class Dialog
        {
            [JsonProperty("target_user")] public Users.User TargetUser { get; set; }

            [JsonProperty("message")] public Users.MessageContent Message { get; set; }
        }
    }
}