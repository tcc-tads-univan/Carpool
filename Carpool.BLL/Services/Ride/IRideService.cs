using Carpool.BLL.Services.Ride.Models;

namespace Carpool.BLL.Services.Ride
{
    public interface IRideService
    {
        Task CreateStudentRideRequest(RideCreateCommand rideCreateCommand);
    }
}
