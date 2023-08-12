using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Ride
{
    public record RideCreateRequest
    {
        [Required]
        public String ScheduleTime { get; set; }
        [Required]
        public int CampusId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
