using System.Text.Json.Serialization;

namespace Carpool.DAL.Infrastructure.Services.Student.Model
{
    public class Student
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("rating")]
        public decimal Rating { get; set; }

        [JsonPropertyName("photoUrl")]
        public string PhotoUrl { get; set; }

        [JsonPropertyName("lineAddress")]
        public string LineAddress { get; set; }
    }
}
