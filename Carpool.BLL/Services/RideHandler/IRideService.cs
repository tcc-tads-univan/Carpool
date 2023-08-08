using Carpool.BLL.Services.RideHandler.Models;

namespace Carpool.BLL.Services.RideHandler
{
    public interface IRideService
    {
        Task CreateStudentRideRequest(RideCreateCommand rideCreateCommand);
    }
}
