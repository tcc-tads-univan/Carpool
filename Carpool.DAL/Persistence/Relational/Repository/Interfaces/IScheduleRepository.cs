using Carpool.DAL.Domain;

namespace Carpool.DAL.Persistence.Relational.Repository.Interfaces
{
    public interface IScheduleRepository
    {
        Task SavePreSchedule(Schedule schedule);
        Task<Schedule> GetPreScheduleByStudentId(int studentId);
        Task AcceptSchedule(int scheduleId);
        Task RejectSchedule(int scheduleId);
        Task<Schedule> GetSchedule(int scheduleId);
    }
}
