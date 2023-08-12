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
            //CallService student

            //Get CampusInformation from DB _campusRepository

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
                ScheduleTime = "12:40"
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

        public async Task<RideStudentResult> GetRideRequestByStudent(int campusId, int studentId)
        {
            var studentRide = await _rideRepository.GetStudentRideRequest(campusId, studentId);
            var ride = new RideStudentResult()
            {
                ScheduleTime = studentRide.ScheduleTime,
                CampusLineAddress = studentRide.CampusLineAddress,
                CampusName = studentRide.CampusName
            };
            return ride;
        }
    }
}
