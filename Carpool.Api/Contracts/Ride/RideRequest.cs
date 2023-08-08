using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Ride
{
    public record RideRequest
    {
        [Required]
        public String ScheduledTime { get; set; }
        [Required]
        public int CampusId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
