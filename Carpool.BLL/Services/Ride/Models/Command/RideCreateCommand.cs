namespace Carpool.BLL.Services.Ride.Models.Command
{
    public record RideCreateCommand
    {
        public string ScheduleTime { get; set; }
        public int CampusId { get; set; }
        public int StudentId { get; set; }
    }
}
