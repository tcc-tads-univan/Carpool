using Carpool.BLL.Common.Errors;
using Carpool.BLL.Services.Ride.Models.Command;
using Carpool.BLL.Services.Ride.Models.Result;
using Carpool.DAL.Infrastructure.Services.Route;
using Carpool.DAL.Infrastructure.Services.Route.Model;
using Carpool.DAL.Infrastructure.Services.Student;
using Carpool.DAL.Persistence.Redis.Interfaces;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;
using FluentResults;

namespace Carpool.BLL.Services.Ride
{
    public class RideService : IRideService
    {
        private readonly IRideRepository _rideRepository;
        private readonly IStudentService _studentService;
        private readonly ICampusRepository _campusRepository;
        private readonly IRouteService _routeService;
        public RideService(IRideRepository rideRepository, ICampusRepository campusRepository, IStudentService studentService, IRouteService routeService)
        {
            _rideRepository = rideRepository;
            _campusRepository = campusRepository;
            _studentService = studentService;
            _routeService = routeService;
        }

        public async Task<Result<RouteResult>> CalculateRideRoute(int campusId, int studentId, int driverId)
        {
            var studentRide = await _rideRepository.GetStudentRideRequest(campusId, studentId);

            if (studentRide is null)
            {
                return Result.Fail(new RideNotFound());
            }

            var routeRequest = new RouteRequest()
            {
                DriverId = driverId,
                CampusPlaceId = studentRide.CampusPlaceId,
                StudentPlaceId = studentRide.StudentPlaceId
            };

            var routeMap = await _routeService.CalculatePath(routeRequest);
            return Result.Ok(new RouteResult(routeMap.GooglePath));
        }

        public async Task<Result> CancelStudentRideRequest(RideDeleteCommand rideDeleteCommand)
        {
            if(!(await _rideRepository.RideExist(
                rideDeleteCommand.CampusId,
                rideDeleteCommand.StudentId)))
            {
                return Result.Fail(new RideNotFound());
            }

            await _rideRepository.DeleteRideRequest(rideDeleteCommand.CampusId, rideDeleteCommand.StudentId);
            return Result.Ok();
        }

        public async Task<Result> CreateStudentRideRequest(RideCreateCommand rideCreateCommand)
        {
            var student = await _studentService.GetStudentBasicInfos(rideCreateCommand.StudentId);

            if(student is null)
            {
                return Result.Fail(new StudentServiceUnavailable());
            }

            DAL.Domain.Campus campus = await _campusRepository.GetCampus(rideCreateCommand.CampusId);
            
            if(campus is null)
            {
                return Result.Fail(new CampusNotFound());
            }

            if (await _rideRepository.RideExist(
                    rideCreateCommand.CampusId,
                    rideCreateCommand.StudentId))
            {
                return Result.Fail(new RideAlreadyExist());
            }

            DAL.Domain.Ride ride = new DAL.Domain.Ride()
            {
                StudentId = rideCreateCommand.StudentId,
                StudentName = student.Name,
                PhoneNumber = student.PhoneNumber,
                CampusLineAddress = campus.LineAddress,
                CampusPlaceId = campus.PlaceId,
                CampusName = campus.CampusName,
                StudentLineAddress = student.LineAddress,
                StudentPlaceId = student.PlaceId,
                PhotoUrl = student.PhotoUrl,
                Rating = student.Rating,
                ScheduleTime = rideCreateCommand.ScheduleTime
            };

            await _rideRepository.CreateRideRequest(rideCreateCommand.CampusId, ride);
            return Result.Ok();
        }

        public async Task<List<RideResult>> GetAllRideRequestsByCampus(int campusId)
        {
            var rideRequests = await _rideRepository.GetAllRideRequests(campusId);
            var rides = rideRequests.Select(r => new RideResult
            {
                StudentId = r.StudentId,
                Name = r.StudentName,
                ScheduleTime = r.ScheduleTime,
                LineAddress = r.StudentLineAddress,
                PhoneNumber = r.PhoneNumber,
                PhotoUrl = r.PhotoUrl,
                Rating = r.Rating
            }).ToList();
            return rides;
        }

        public async Task<Result<RideStudentResult>> GetRideRequestByStudent(int campusId, int studentId)
        {
            var studentRide = await _rideRepository.GetStudentRideRequest(campusId, studentId);
            
            if(studentRide is null)
            {
                return Result.Fail(new RideNotFound());
            }

            var ride = new RideStudentResult()
            {
                ScheduleTime = studentRide.ScheduleTime,
                CampusLineAddress = studentRide.CampusLineAddress,
                CampusName = studentRide.CampusName
            };

            return Result.Ok(ride);
        }
    }
}
