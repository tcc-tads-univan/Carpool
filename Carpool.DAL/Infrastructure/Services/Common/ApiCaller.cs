using System.Text.Json;

namespace Carpool.DAL.Infrastructure.Services.Common
{
    public class ApiCaller : IApiCaller
    {
        private readonly HttpClient _client;
        public ApiCaller(HttpClient client)
        {
            _client = client;
        }
        public async Task<T> GetUserInformation<T>(HttpMethod method, string url)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            var response = await _client.SendAsync(request);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonResponse);
        }
    }
}
