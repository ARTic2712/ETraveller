using ETraveller.Common.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ETraveller.Common.Extensions
{
    public static class HttpClientExtension
    {
        public async static Task<ProviderResult<T>> GetResultAsync<T>(this HttpClient httpClient, string requestUri)
        {
            var response  = await httpClient.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var result = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                return new ProviderResult<T>(true, result, null);
            }
            else
            {
                return new ProviderResult<T>(false, default(T), response.StatusCode.ToString());
            }
        }
    }
}
