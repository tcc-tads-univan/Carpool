using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Ride
{
    public record RouteRequest
    {
        [Required]
        public int DriverId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
