namespace Carpool.BLL.Services.Ride.Models
{
    public record RideDeleteCommand
    {
        public int CampusId { get; set; }
        public int StudentId { get; set; }
    }
}
