namespace Carpool.DAL.Domain
{
    public class Ride
    {
        public int StudentId { get; set; }
        public String StudentName { get; set; }
        public String ScheduledTime { get; set; }
        public String CampusLineAddress { get; set; }
        public String CampusName { get; set; }
        public String LineAddress { get; set; }
        public String PhotoUrl { get; set; }
        public String PhoneNumber { get; set; }
        public decimal Rating { get; set; }
    }
}
