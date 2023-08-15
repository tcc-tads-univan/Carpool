namespace Carpool.Api.Contracts.Schedule.Response
{
    public record ScheduleResponse
    {
        public int ScheduleId { get; set; }
        public String ScheduleTime { get; set; }
        public String OriginAddress { get; set; }
        public String DestinationAddress { get; set; }
        public decimal RidePrice { get; set; }
        public DriverResponse Driver { get; set; }
    }

    public class DriverResponse
    {
        public String Name { get; set; }
        public String photoUrl { get; set; }
        public decimal rating { get; set; }
        public String phoneNumber { get; set; }
        public String vehiclePlate { get; set; }
    }
}
