using System.Threading.Tasks;
using ShikimoriSharp.Bases;
using ShikimoriSharp.Classes;

namespace ShikimoriSharp.Information
{
    public class Characters : ApiBase
    {
        public Characters(ApiClient apiClient) : base(Version.v1, apiClient)
        {
        }

        public async Task<Character[]> GetCharactersBySearch(string search)
        {
            return await Request<Character[], Search>("characters/search", new Search {search = search});
        }

        public async Task<FullCharacter> GetCharacterById(long id, AccessToken personalInformation = null)
        {
            return await Request<FullCharacter>($"characters/{id}", personalInformation);
        }
    }
}