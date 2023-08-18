using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Ride
{
    public record RideCreateRequest
    {
        [Required]
        [RegularExpression(@"^([0-9]{2}):([0-9]{2})$", ErrorMessage = "Invalid Schedule Time")]
        public String ScheduleTime { get; set; }
        [Required]
        public int CampusId { get; set; }
        [Required]
        public int StudentId { get; set; }
    }
}
