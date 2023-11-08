namespace Carpool.BLL.Services.Schedule.Models.Command
{
    public class ScheduleCreateCommand
    {
        public int StudentId { get; set; }
        public int DriverId { get; set; }
        public int CampusId { get; set; }
        public decimal Price { get; set; }
    }
}
