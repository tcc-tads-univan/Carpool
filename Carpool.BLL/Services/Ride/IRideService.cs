using Carpool.BLL.Services.Ride.Models.Command;
using Carpool.BLL.Services.Ride.Models.Result;
using FluentResults;

namespace Carpool.BLL.Services.Ride
{
    public interface IRideService
    {
        Task<Result> CreateStudentRideRequest(RideCreateCommand rideCreateCommand);
        Task<Result> CancelStudentRideRequest(RideDeleteCommand rideDeleteCommand);
        Task<Result<RouteResult>> CalculateRideRoute(int campusId, int studentId, int driverId);
        Task<List<RideResult>> GetAllRideRequestsByCampus(int campusId);
        Task<Result<RideStudentResult>> GetRideRequestByStudent(int campusId, int studentId);
    }
}
