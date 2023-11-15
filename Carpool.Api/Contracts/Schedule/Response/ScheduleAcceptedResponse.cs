namespace Carpool.Api.Contracts.Schedule.Response
{
    public class ScheduleAcceptedResponse
    {
        public int ScheduleId { get; set; }
        public String ScheduleTime { get; set; }
        public String OriginAddress { get; set; }
        public String DestinationAddress { get; set; }
        public decimal RidePrice { get; set; }
        public StudentResponse Student { get; set; }
    }

    public class StudentResponse
    {
        public int StudentId { get; set; }
        public String Name { get; set; }
        public String PhotoUrl { get; set; }
        public decimal Rating { get; set; }
        public String PhoneNumber { get; set; }
    }
}
