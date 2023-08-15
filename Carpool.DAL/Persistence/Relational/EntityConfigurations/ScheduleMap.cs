using Carpool.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpool.DAL.Persistence.Relational.EntityConfigurations
{
    public class ScheduleMap : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedule");
            builder.HasKey(c => c.ScheduleId);
            builder.Property(c => c.DriverId).IsRequired();
            builder.Property(c => c.StudentId).IsRequired();
            builder.Property(c => c.ScheduleTime).IsRequired().HasMaxLength(5);
            builder.Property(c => c.RequestDate).IsRequired();
            builder.Property(c => c.Origin).HasMaxLength(120);
            builder.Property(c => c.Destination).HasMaxLength(120);
            builder.Property(c => c.RidePrice).HasPrecision(7,2);
        }
    }
}
