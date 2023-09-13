using System.Text.Json.Serialization;

namespace Carpool.DAL.Infrastructure.Services.Driver.Model
{
    public class Driver
    {
        [JsonPropertyName("name")]
        public String Name { get; set; }

        [JsonPropertyName("photoUrl")]
        public String PhotoUrl { get; set; }

        [JsonPropertyName("rating")]
        public decimal Rating { get; set; }

        [JsonPropertyName("phoneNumber")]
        public String PhoneNumber { get; set; }

        [JsonPropertyName("vehiclePlate")]
        public String VehiclePlate { get; set; }
    }
}
