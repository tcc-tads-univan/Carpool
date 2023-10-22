namespace Carpool.DAL.Domain.Event
{
    public abstract class BaseEvent
    {
        public int StudentId { get; set; }
        public int DriverId { get; set; }
    }
}
