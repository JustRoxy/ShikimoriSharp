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

        public async Task<Dialog[]> GetDialogs()
        {
            return await Request<Dialog[]>("dialogs", true);
        }

        public async Task<Message[]> GetDialogs(string fromNickname)
        {
            return await Request<Message[]>($"dialogs/{fromNickname}", true);
        }
    }
}