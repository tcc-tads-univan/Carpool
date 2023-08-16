using Carpool.DAL.Domain;
using Carpool.DAL.Persistence.Relational.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Carpool.DAL.Persistence.Relational.Context
{
    public class CarpoolContext : DbContext
    {
        public CarpoolContext(DbContextOptions<CarpoolContext> options) : base(options)
        {

        }

        public DbSet<College> College { get; set; }
        public DbSet<Campus> Campus { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<College>(new CollegeMap().Configure);
            builder.Entity<Campus>(new CampusMap().Configure);
            builder.Entity<Schedule>(new ScheduleMap().Configure);

            builder.Entity<Campus>().HasOne<College>(ca => ca.College).WithMany(co => co.Campi).HasForeignKey(f => f.CollegeId);
        }
    }
}
