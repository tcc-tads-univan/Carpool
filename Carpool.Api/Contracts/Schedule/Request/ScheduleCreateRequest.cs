using System.ComponentModel.DataAnnotations;

namespace Carpool.Api.Contracts.Schedule.Request
{
    public record ScheduleCreateRequest
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int DriverId { get; set; }
        [Required]
        public int CampusId { get; set; }
    }
}
