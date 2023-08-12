using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Ride.Request
{
    public record RouteRequest
    {
        [Required]
        public int DriverId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
