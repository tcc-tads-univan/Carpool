using System.Text.Json.Serialization;

namespace Carpool.DAL.Infrastructure.Services.Route.Model
{
    public class RouteMap
    {
        [JsonPropertyName("")]
        public string GooglePath { get; set; }
    }
}
