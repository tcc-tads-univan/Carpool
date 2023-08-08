using Carpool.DAL.Domain;

namespace Carpool.DAL.Persistence.Redis.Interfaces
{
    public interface IRideRepository
    {
        Task CreateRideRequest(int campusId, Ride ride);

        Task DeleteRideRequest(int campusId, int studentId);

        Task<IEnumerable<Ride>> GetAllRideRequests(int campusId);

        Task<Ride> GetStudentRideRequest(int campusId, int studentId);
    }
}
