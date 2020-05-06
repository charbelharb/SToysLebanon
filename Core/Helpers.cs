using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Helpers
    {
        public static string GenerateName(string prefix, string originalName)
        {
            return $"{prefix}{DateTime.UtcNow.Ticks}{originalName}";
        }

        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(this HttpClient client, string requestUri, T data) where T : class
        {
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await client.PostAsync(requestUri, content);
        }
    }
}
