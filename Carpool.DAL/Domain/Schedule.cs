namespace Carpool.DAL.Domain
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime RequestDate { get; set; }
        public int StudentId { get; set; }
        public String ScheduleTime { get; set; }
        public int DriverId { get; set; }
        public String Origin { get; set; }
        public String Destination { get; set; }
        public decimal RidePrice { get; set; }
        public bool Accepted { get; set; }
    }
}
