using Carpool.BLL.Services.Schedule.Models.Command;
using Carpool.BLL.Services.Schedule.Models.Result;
using Carpool.DAL.Domain;
using Carpool.DAL.Persistence.Redis.Interfaces;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;

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
        public async Task CreatePreSchedule(ScheduleCreateCommand command)
        {
            //1 - Call redis to get StudentInformations
            var rideInformations = await _rideRepository.GetStudentRideRequest(command.CampusId, command.StudentId);

            //2 - Create DAL objetct
            DAL.Domain.Schedule schedule = new DAL.Domain.Schedule
            {
                StudentId = rideInformations.StudentId,
                DriverId = command.DriverId,
                Origin = rideInformations.CampusLineAddress,
                Destination = rideInformations.StudentLineAddress,
                ScheduleTime = rideInformations.ScheduleTime,
                RequestDate = DateTime.Now,
                RidePrice = 12.23M
            };

            await _scheduleRepository.SavePreSchedule(schedule);
            
            //4 - send notification to student

        }

        public async Task<ScheduleResult> GetSchedule(int scheduleId)
        {
            var schedule= await _scheduleRepository.GetSchedule(scheduleId);
            
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
            return scheduleResult;
        }

        public async Task<ScheduleResult> GetStudentPreSchedule(int studentId)
        {
            var schedule = await _scheduleRepository.GetPreScheduleByStudentId(studentId);

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

            return studentScheduleResult;
        }

        public async Task StudentAcceptSchedule(int scheduleId)
        {
            await _scheduleRepository.AcceptSchedule(scheduleId);
            //send notification
        }

        public async Task StudentRejectSchedule(int scheduleId)
        {
            await _scheduleRepository.RejectSchedule(scheduleId);
            //send notification
        }
    }
}
