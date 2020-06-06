using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;

namespace ShikimoriSharp.UpdatableInformation
{
    public class Dialogs : ApiBase
    {
        public Dialogs(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Dialog[]> GetDialogs(AccessToken personalInformation)
        {
            return await Request<Dialog[]>("dialogs", personalInformation);
        }

        public async Task<Message[]> GetDialogs(string fromNickname, AccessToken personalInformation)
        {
            return await Request<Message[]>($"dialogs/{fromNickname}", personalInformation);
        }
    }
}