
namespace Carpool.BLL.Services.Ride.Models
{
    public record RideCreateCommand
    {
        public String ScheduledTime { get; set; }
        public int CampusId { get; set; }
        public int StudentId { get; set; }
    }
}
