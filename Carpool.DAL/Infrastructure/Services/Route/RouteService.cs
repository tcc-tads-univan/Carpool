using Carpool.DAL.Infrastructure.Services.Route.Model;
using System.Text;
using System.Text.Json;

namespace Carpool.DAL.Infrastructure.Services.Route
{
    public class RouteService : IRouteService
    {
        private readonly HttpClient _client;
        public RouteService(HttpClient client)
        {
            _client = client;
        }

        public async Task<RouteMap> CalculatePath(RouteRequest route)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "calculate");
            request.Content = BuildRequestContent(route);

            var response = await _client.SendAsync(request);
            var routeResult = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<RouteMap>(routeResult);
        }

        private StringContent BuildRequestContent(RouteRequest route)
        {
            var json = JsonSerializer.Serialize(route);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
