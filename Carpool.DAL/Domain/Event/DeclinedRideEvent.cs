namespace Carpool.DAL.Domain.Event
{
    public class DeclinedRideEvent : BaseEvent
    {
        public string Origin { get; set; }
        public string ScheduleTime { get; set; }
    }
}
