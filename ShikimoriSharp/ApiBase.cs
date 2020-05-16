using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShikimoriSharp
{
    public abstract class ApiBase
    {
        private ApiClient _apiClient;
        public Version Version { get; }

        private string GetThing()
        {
            return Version switch
            {
                Version.v1 => "",
                _ => Version + "/"
            };
        }
        private string Site => $"https://shikimori.one/api/{GetThing()}";

        protected ApiBase(Version version, ApiClient apiClient)
        {
            Version = version;
            _apiClient = apiClient;
        }

        private static HttpContent DeserializeToRequest<T>(T obj)
        {
            var typeooft = obj.GetType();
            var type = typeooft.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var typeEnum = type.Select(it => new
                    {Name = it.Name, Value = typeooft.GetField(it.Name)?.GetValue(obj)})
                .Where(it => !(it.Value is null));
            var content = new MultipartFormDataContent();
            foreach (var i in typeEnum)
                content.Add(new StringContent(i.Value.ToString()), i.Name);
            

            return content;
        }

        public async Task<TResult> Request<TResult, TSettings>(string apiMethod, TSettings settings, bool protectedResource = false)
        {
            var settingsInfo = DeserializeToRequest(settings);
            return await _apiClient.RequestApi<TResult>($"{Site}{apiMethod}", settingsInfo, protectedResource);
        }
    }

    public enum Version
    {
        v1,
        v2
    }
}