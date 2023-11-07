namespace Carpool.DAL.Domain
{
    public class Ride
    {
        public int StudentId { get; set; }
        public String StudentName { get; set; }
        public String ScheduleTime { get; set; }
        public String CampusLineAddress { get; set; }
        public String CampusName { get; set; }
        public String CampusPlaceId { get; set; }
        public String StudentLineAddress { get; set; }
        public String StudentPlaceId { get; set; }
        public String PhotoUrl { get; set; }
        public String PhoneNumber { get; set; }
        public decimal Rating { get; set; }
    }
}
