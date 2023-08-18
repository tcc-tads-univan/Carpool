using Carpool.BLL.Services.Ride.Models.Command;
using Carpool.BLL.Services.Ride.Models.Result;
using FluentResults;

namespace Carpool.BLL.Services.Ride
{
    public interface IRideService
    {
        Task<Result> CreateStudentRideRequest(RideCreateCommand rideCreateCommand);
        Task CancelStudentRideRequest(RideDeleteCommand rideDeleteCommand);
        Task CalculateRideRoute();
        Task<List<RideResult>> GetAllRideRequestsByCampus(int campusId);
        Task<RideStudentResult> GetRideRequestByStudent(int campusId, int studentId);
    }
}
