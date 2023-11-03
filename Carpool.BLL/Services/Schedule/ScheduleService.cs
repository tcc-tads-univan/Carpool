using Carpool.BLL.Common.Errors;
using Carpool.BLL.Services.Schedule.Models.Command;
using Carpool.BLL.Services.Schedule.Models.Result;
using Carpool.DAL.Infrastructure.Messaging;
using Carpool.DAL.Infrastructure.Services.Driver;
using Carpool.DAL.Infrastructure.Services.Driver.Model;
using Carpool.DAL.Infrastructure.Services.Student;
using Carpool.DAL.Persistence.Redis.Interfaces;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;
using FluentResults;
using SharedContracts;

namespace Carpool.BLL.Services.Schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRideRepository _rideRepository;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IDriverService _driverService;
        private readonly IStudentService _studentService;
        private readonly IMessageSender _messageSender;

        public ScheduleService(IRideRepository rideRepository, IScheduleRepository scheduleRepository, IDriverService driverService, IMessageSender messageSender, IStudentService studentService)
        {
            _rideRepository = rideRepository;
            _scheduleRepository = scheduleRepository;
            _driverService = driverService;
            _studentService = studentService;
            _messageSender = messageSender;
        }
        public async Task<Result> CreatePreSchedule(ScheduleCreateCommand command)
        {
            var studentRide = await _rideRepository.GetStudentRideRequest(command.CampusId, command.StudentId);

            if (studentRide is null)
            {
                return Result.Fail(new RideNotFound());
            }

            var driver = await _driverService.GetDriverBasicInfos(command.DriverId);

            if (driver is null)
            {
                return Result.Fail(new DriverServiceUnavailable());
            }

            DAL.Domain.Schedule schedule = new DAL.Domain.Schedule
            {
                StudentId = studentRide.StudentId,
                StudentName = studentRide.StudentName,
                DriverId = command.DriverId,
                DriverName = driver.Name,
                Origin = studentRide.CampusLineAddress,
                Destination = studentRide.StudentLineAddress,
                ScheduleTime = studentRide.ScheduleTime,
                RequestDate = DateTime.Now,
                CampusId = command.CampusId,
                RidePrice = 12.23M
            };

            await _scheduleRepository.SavePreSchedule(schedule);

            await _messageSender.SendInvitedRideEvent(CreateInvitedRideEvent(schedule));

            return Result.Ok();
        }

        public async Task<Result<ScheduleResult>> GetSchedule(int scheduleId)
        {
            var schedule = await _scheduleRepository.GetSchedule(scheduleId);
            
            if(schedule is null)
            {
                return Result.Fail(new ScheduleNotFound());
            }

            var driver = await _driverService.GetDriverBasicInfos(schedule.DriverId);

            if (driver is null)
            {
                return Result.Fail(new DriverServiceUnavailable());
            }
            
            return Result.Ok(MapScheduleResult(driver, schedule));
        }

        public async Task<Result<ScheduleResult>> GetStudentPreSchedule(int studentId)
        {
            var schedule = await _scheduleRepository.GetPreScheduleByStudentId(studentId);

            if (schedule is null)
            {
                return Result.Fail(new ScheduleInvalid());
            }

            var driver = await _driverService.GetDriverBasicInfos(schedule.DriverId);

            if(driver is null)
            {
                return Result.Fail(new DriverServiceUnavailable());
            }

            return Result.Ok(MapScheduleResult(driver, schedule));
        }

        public async Task<Result> StudentAcceptSchedule(int scheduleId)
        {
            if(!(await _scheduleRepository.isValidSchedule(scheduleId)))
            {
                return Result.Fail(new ScheduleInvalid());
            }

            var schedule = await _scheduleRepository.GetSchedule(scheduleId);

            await _scheduleRepository.AcceptSchedule(scheduleId);
            await _rideRepository.DeleteRideRequest(schedule.CampusId, schedule.StudentId);

            await _messageSender.SendSaveTripEvent(CreateSaveTripEvent(schedule));

            return Result.Ok();
        }

        public async Task<Result> StudentRejectSchedule(int scheduleId)
        {
            if (!(await _scheduleRepository.isValidSchedule(scheduleId)))
            {
                return Result.Fail(new ScheduleInvalid());
            }

            await _scheduleRepository.RejectSchedule(scheduleId);
            var rejectedSchedule = await _scheduleRepository.GetSchedule(scheduleId);

            await _messageSender.SendDeclinedRideEvent(CreateDeclinedEvent(rejectedSchedule));

            return Result.Ok();
        }

        private DeclinedRideEvent CreateDeclinedEvent(DAL.Domain.Schedule rejectedSchedule)
        {
            return new DeclinedRideEvent()
            {
                DriverId = rejectedSchedule.DriverId,
                StudentId = rejectedSchedule.StudentId,
                Origin = rejectedSchedule.Origin,
                ScheduleTime = rejectedSchedule.ScheduleTime
            };
        }

        private SaveTripEvent CreateSaveTripEvent(DAL.Domain.Schedule schedule)
        {
            return new SaveTripEvent()
            {
                DriverId = schedule.DriverId,
                StudentId = schedule.StudentId,
                FinalDestination = schedule.Destination,
                InitialDestination = schedule.Origin,
                Price = schedule.RidePrice,
                DriverName = schedule.DriverName,
                StudentName = schedule.StudentName
            };
        }

        private InvitedRideEvent CreateInvitedRideEvent(DAL.Domain.Schedule schedule)
        {
            return new InvitedRideEvent()
            {
                DriverId = schedule.DriverId,
                RidePrice = schedule.RidePrice,
                ScheduleTime = schedule.ScheduleTime,
                StudentId = schedule.StudentId
            };
        }

        private ScheduleResult MapScheduleResult(Driver driver, DAL.Domain.Schedule schedule)
        {
            return new ScheduleResult()
            {
                ScheduleId = schedule.ScheduleId,
                DestinationAddress = schedule.Destination,
                OriginAddress = schedule.Origin,
                ScheduleTime = schedule.ScheduleTime,
                RidePrice = schedule.RidePrice,
                Driver = new DriverResult()
                {
                    Name = driver.Name,
                    PhoneNumber = driver.PhoneNumber,
                    PhotoUrl = driver.PhotoUrl,
                    Rating = driver.Rating,
                    VehiclePlate = driver.VehiclePlate
                }
            };
        }
    }
}
