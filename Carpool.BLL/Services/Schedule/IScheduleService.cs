using Carpool.BLL.Services.Schedule.Models.Command;
using Carpool.BLL.Services.Schedule.Models.Result;

namespace Carpool.BLL.Services.Schedule
{
    public interface IScheduleService
    {
        Task CreatePreSchedule(ScheduleCreateCommand command);
        Task StudentAcceptSchedule(int scheduleId);
        Task StudentRejectSchedule(int scheduleId);
        Task<ScheduleResult> GetStudentPreSchedule(int studentId);
        Task<ScheduleResult> GetSchedule(int scheduleId);
    }
}
