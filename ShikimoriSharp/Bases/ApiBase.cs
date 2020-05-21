using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikimoriSharp.Bases
{
    public abstract class ApiBase
    {
        private readonly ApiClient _apiClient;

        protected ApiBase(Version version, ApiClient apiClient)
        {
            Version = version;
            _apiClient = apiClient;
        }

        public Version Version { get; }
        private string Site => $"https://shikimori.one/api/{GetThing()}";

        private string GetThing()
        {
            return Version switch
            {
                Version.v1 => "",
                _ => Version + "/"
            };
        }

        private static HttpContent DeserializeToRequest<T>(T obj)
        {
            if (obj is null) return null;
            var typeooft = obj.GetType();
            var type = typeooft.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var typeEnum = type.Select(it => new
                {
                    it.Name, Value = typeooft.GetField(it.Name)?.GetValue(obj)
                })
                .Where(it => !(it.Value is null));
            var content = new MultipartFormDataContent();
            foreach (var i in typeEnum)
                content.Add(new StringContent(i.Value.ToString()), i.Name);


            return content;
        }

        public async Task<TResult> Request<TResult, TSettings>(string apiMethod, TSettings settings,
            bool protectedResource = false, string method = "GET")
        {
            var settingsInfo = DeserializeToRequest(settings);
            return await _apiClient.RequestApi<TResult>($"{Site}{apiMethod}", settingsInfo, protectedResource, method);
        }

        private static async Task<string> SerializeToJson(object obj)
        {
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(obj));
        }

        public async Task<TResult> SendJson<TResult>(string apiMethod, object content, bool protectedResource,
            string method = "POST")
        {
            var json = new StringContent(await SerializeToJson(content), Encoding.UTF8, "application/json");
            return await _apiClient.RequestApi<TResult>($"{Site}{apiMethod}", json, protectedResource, method);
        }

        public async Task<TResult> Request<TResult>(string apiMethod, bool protectedResource = false,
            string method = "GET")
        {
            return await _apiClient.RequestApi<TResult>($"{Site}{apiMethod}", protectedResource);
        }

        public async Task NoResponseRequest(string apiMethod, bool protectedResource = true, string method = "POST")
        {
            await _apiClient.NoResponseRequest($"{Site}{apiMethod}", null, protectedResource, method);
        }

        public async Task NoResponseRequest<TSettings>(string apiMethod, TSettings setting,
            bool protectedResource = true, string method = "POST")
        {
            var settings = DeserializeToRequest(setting);
            await _apiClient.NoResponseRequest($"{Site}{apiMethod}", settings, protectedResource);
        }
    }

    public enum Version
    {
        v1,
        v2
    }
}