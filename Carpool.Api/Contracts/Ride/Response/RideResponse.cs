namespace Carpool.Api.Contracts.Ride.Response
{
    public class RideResponse
    {
        public int StudentId { get; set; }
        public String Name { get; set; }
        public String ScheduleTime { get; set; }
        public String PhoneNumber { get; set; }
        public String LineAddress { get; set; }
        public String PhotoUrl { get; set; }
        public decimal Rating { get; set; }
    }
}
