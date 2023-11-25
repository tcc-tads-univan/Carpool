using Carpool.DAL.Domain;

namespace Carpool.DAL.Persistence.Relational.Repository.Interfaces
{
    public interface IScheduleRepository
    {
        Task SavePreSchedule(Schedule schedule);
        Task<Schedule> GetPreScheduleByStudentId(int studentId);
        Task<List<Schedule>> GetTodayAcceptedScheduleByDriverId(int driverId);
        Task AcceptSchedule(int scheduleId);
        Task RejectSchedule(int scheduleId);
        Task CompleteSchedule(int scheduleId);
        Task<Schedule> GetSchedule(int scheduleId);
        Task<bool> IsValidSchedule(int scheduleId);
    }
}
