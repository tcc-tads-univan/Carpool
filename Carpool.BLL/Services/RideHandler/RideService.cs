using Carpool.BLL.Services.RideHandler.Models;
using Carpool.DAL.Domain;
using Carpool.DAL.Persistence.Redis.Interfaces;

namespace Carpool.BLL.Services.RideHandler
{
    public class RideService : IRideService
    {
        private readonly IRideRepository _rideRepository;
        public RideService(IRideRepository rideRepository)
        {
            _rideRepository = rideRepository;
        }

        public async Task CreateStudentRideRequest(RideCreateCommand rideCreateCommand)
        {
            //CallService

            Ride ride = new Ride()
            {
                StudentId = 1,
                StudentName = "Mateus",
                PhoneNumber = "213123",
                LineAddress = "Rua asdsad",
                PhotoUrl = "blobStorage",
                Rating = 4.2M,
                ScheduledTime = "12:40"
            };

            await _rideRepository.CreateRideRequest(rideCreateCommand.CampusId, ride);
        }
    }
}
