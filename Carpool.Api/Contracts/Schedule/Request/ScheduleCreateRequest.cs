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

        [Required]
        [RegularExpression(@"^\d+.\d{2}$", ErrorMessage = "Invalid Price Format")]
        public decimal Price { get; set; }
    }
}
