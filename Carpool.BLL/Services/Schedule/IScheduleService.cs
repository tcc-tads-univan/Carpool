using Carpool.BLL.Services.Schedule.Models.Command;
using Carpool.BLL.Services.Schedule.Models.Result;
using FluentResults;

namespace Carpool.BLL.Services.Schedule
{
    public interface IScheduleService
    {
        Task<Result> CreatePreSchedule(ScheduleCreateCommand command);
        Task<Result> StudentAcceptSchedule(int scheduleId);
        Task<Result> StudentRejectSchedule(int scheduleId);
        Task<Result> CompleteSchedule(int scheduleId);
        Task<Result<ScheduleResult>> GetStudentPreSchedule(int studentId);
        Task<Result<List<ScheduleAcceptedResult>>> GetTodayAcceptedScheduleByDriverId(int driverId);
        Task<Result<ScheduleResult>> GetSchedule(int scheduleId);
    }
}
