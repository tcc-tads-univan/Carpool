using Carpool.BLL.Services.Ride.Models.Command;
using Carpool.BLL.Services.Ride.Models.Result;
using Carpool.DAL.Persistence.Redis.Interfaces;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;

namespace Carpool.BLL.Services.Ride
{
    public class RideService : IRideService
    {
        private readonly IRideRepository _rideRepository;
        private readonly ICampusRepository campusRepository;
        public RideService(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        public Task CalculateRideRoute()
        {
            throw new NotImplementedException();
        }

        public async Task CancelStudentRideRequest(RideDeleteCommand rideDeleteCommand)
        {
            await _rideRepository.DeleteRideRequest(rideDeleteCommand.CampusId, rideDeleteCommand.StudentId);
        }

        public async Task CreateStudentRideRequest(RideCreateCommand rideCreateCommand)
        {
            //CallService

            //Get CampusInformation from DB _campusRepositor

            DAL.Domain.Ride ride = new DAL.Domain.Ride()
            {
                StudentId = 1,
                StudentName = "Mateus",
                PhoneNumber = "213123",
                CampusLineAddress = "",
                CampusName = "",
                LineAddress = "Rua asdsad",
                PhotoUrl = "blobStorage",
                Rating = 4.2M,
                ScheduledTime = "12:40"
            };

            await _rideRepository.CreateRideRequest(rideCreateCommand.CampusId, ride);
        }

        public async Task<IEnumerable<RideResult>> GetAllRideRequestsByCampus(int campusId)
        {
            var rideRequests = await _rideRepository.GetAllRideRequests(campusId);
            var rides = rideRequests.Select(r => new RideResult
            {
                StudentId = r.StudentId,
                Name = r.StudentName,
                LineAddress = r.LineAddress,
                PhoneNumber = r.PhoneNumber,
                PhotoUrl = r.PhotoUrl,
                Rating = r.Rating
            });
            return rides;
        }

        public Task<RideStudentResult> GetRideRequestByStudent(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
