namespace Carpool.DAL.Domain.Event
{
    public class InvitedRideEvent : BaseEvent
    {
        public string ScheduleTime { get; set; }
        public decimal RidePrice { get; set; }
    }
}
