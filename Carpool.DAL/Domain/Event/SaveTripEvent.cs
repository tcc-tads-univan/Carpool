namespace Carpool.DAL.Domain.Event
{
    public class SaveTripEvent : BaseEvent
    {
        public string StudentName { get; set; }
        public string DriverName { get; set; }
        public string InitialDestination { get; set; }
        public string FinalDestination { get; set; }
        public decimal Price { get; set; }
    }
}
