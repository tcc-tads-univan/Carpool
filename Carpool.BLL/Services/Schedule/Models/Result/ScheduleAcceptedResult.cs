namespace Carpool.BLL.Services.Schedule.Models.Result
{
    public class ScheduleAcceptedResult
    {
        public int ScheduleId { get; set; }
        public String ScheduleTime { get; set; }
        public String OriginAddress { get; set; }
        public String DestinationAddress { get; set; }
        public decimal RidePrice { get; set; }
        public StudentResult Student { get; set; }
    }
}
