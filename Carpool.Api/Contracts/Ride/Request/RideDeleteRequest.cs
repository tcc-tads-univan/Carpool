using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Ride
{
    public record RideDeleteRequest
    {
        [Required]
        public int CampusId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
