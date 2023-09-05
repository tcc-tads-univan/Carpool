using Carpool.BLL.Common.Errors;
using Carpool.BLL.Services.Schedule.Models.Command;
using Carpool.BLL.Services.Schedule.Models.Result;
using Carpool.DAL.Persistence.Redis.Interfaces;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;
using FluentResults;

namespace Carpool.BLL.Services.Schedule
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRideRepository _rideRepository;
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IRideRepository rideRepository, IScheduleRepository scheduleRepository)
        {
            _rideRepository = rideRepository;
            _scheduleRepository = scheduleRepository;
        }
        public async Task<Result> CreatePreSchedule(ScheduleCreateCommand command)
        {
            //1 - Call redis to get StudentInformations
            var studentRide = await _rideRepository.GetStudentRideRequest(command.CampusId, command.StudentId);

            if(studentRide is null)
            {
                return Result.Fail(new RideNotFound());
            }

            //2 - Create DAL objetct
            DAL.Domain.Schedule schedule = new DAL.Domain.Schedule
            {
                StudentId = studentRide.StudentId,
                DriverId = command.DriverId,
                Origin = studentRide.CampusLineAddress,
                Destination = studentRide.StudentLineAddress,
                ScheduleTime = studentRide.ScheduleTime,
                RequestDate = DateTime.Now,
                CampusId = command.CampusId,
                RidePrice = 12.23M
            };

            await _scheduleRepository.SavePreSchedule(schedule);
            await _rideRepository.DeleteRideRequest(command.CampusId, command.StudentId);

            //4 - send notification to student

            return Result.Ok();
        }

        public async Task<Result<ScheduleResult>> GetSchedule(int scheduleId)
        {
            var schedule = await _scheduleRepository.GetSchedule(scheduleId);
            
            if(schedule is null)
            {
                return Result.Fail(new ScheduleNotFound());
            }

            var driverInformation = new DriverResult();

            var scheduleResult = new ScheduleResult()
            {
                ScheduleId = schedule.ScheduleId,
                DestinationAddress = schedule.Destination,
                OriginAddress = schedule.Origin,
                ScheduleTime = schedule.ScheduleTime,
                RidePrice = schedule.RidePrice,
                Driver = driverInformation
            };
            return Result.Ok(scheduleResult);
        }

        public async Task<Result<ScheduleResult>> GetStudentPreSchedule(int studentId)
        {
            var schedule = await _scheduleRepository.GetPreScheduleByStudentId(studentId);

            if (schedule is null)
            {
                return Result.Fail(new ScheduleInvalid());
            }

            //call infrastructure service
            //getFromRedis driver informations
            //design pattern decorator!
            var driverInformation = new DriverResult();

            var studentScheduleResult = new ScheduleResult()
            {
                ScheduleId = schedule.ScheduleId,
                DestinationAddress = schedule.Destination,
                OriginAddress = schedule.Origin,
                ScheduleTime = schedule.ScheduleTime,
                RidePrice = schedule.RidePrice,
                Driver = driverInformation
            };

            return Result.Ok(studentScheduleResult);
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
            
            //send notification
            return Result.Ok();
        }

        public async Task<Result> StudentRejectSchedule(int scheduleId)
        {
            if (!(await _scheduleRepository.isValidSchedule(scheduleId)))
            {
                return Result.Fail(new ScheduleInvalid());
            }

            await _scheduleRepository.RejectSchedule(scheduleId);
            //send notification
            return Result.Ok();
        }
    }
}
