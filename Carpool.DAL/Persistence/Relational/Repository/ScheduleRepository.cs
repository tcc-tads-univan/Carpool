﻿using Carpool.DAL.Domain;
using Carpool.DAL.Persistence.Relational.Context;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carpool.DAL.Persistence.Relational.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly DbSet<Schedule> _schedule;
        private readonly CarpoolContext _context;
        public ScheduleRepository(CarpoolContext context)
        {
            _context = context;
            _schedule = context.Set<Schedule>();
        }
        public async Task AcceptSchedule(int scheduleId)
        {
            var schedule = await _schedule.SingleOrDefaultAsync(s => s.ScheduleId == scheduleId);
            schedule.Accepted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Schedule> GetPreScheduleByStudentId(int studentId)
        {
            var schedule = await _schedule.Where(s => s.StudentId == studentId && s.Accepted == null)
                .OrderByDescending(s => s.RequestDate)
                .FirstOrDefaultAsync();
            return schedule;
        }

        public async Task<Schedule> GetSchedule(int scheduleId)
        {
            var schedule = await _schedule.SingleOrDefaultAsync(s => s.ScheduleId == scheduleId);
            return schedule;
        }

        public async Task RejectSchedule(int scheduleId)
        {
            var schedule = await _schedule.SingleOrDefaultAsync(s => s.ScheduleId == scheduleId);
            schedule.Accepted = false;
            await _context.SaveChangesAsync();
        }

        public async Task SavePreSchedule(Schedule schedule)
        {
            await _schedule.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsValidSchedule(int scheduleId)
        {
            return await _schedule.AnyAsync(s => s.ScheduleId == scheduleId && s.Accepted == null);
        }

        public Task<List<Schedule>> GetTodayAcceptedScheduleByDriverId(int driverId)
        {
            var today = DateTime.Now.Date;
            return _schedule.Where(s => s.DriverId == driverId 
                && s.Accepted.Value 
                && !s.Completed.HasValue
                && s.RequestDate.Date == today).ToListAsync();
        }

        public async Task CompleteSchedule(int scheduleId)
        {
            var schedule = await _schedule.SingleOrDefaultAsync(s => s.ScheduleId == scheduleId);
            schedule.Completed = true;
            await _context.SaveChangesAsync();
        }
    }
}
