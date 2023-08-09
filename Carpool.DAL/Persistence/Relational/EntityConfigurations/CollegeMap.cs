using Carpool.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpool.DAL.Persistence.Relational.EntityConfigurations
{
    public class CollegeMap : IEntityTypeConfiguration<College>
    {
        public void Configure(EntityTypeBuilder<College> builder)
        {
            builder.ToTable("College");
            builder.HasKey(c => c.CollegeId);
            builder.Property(c => c.CollegeName).IsRequired().HasMaxLength(120);
            builder.Property(c => c.Acronym).IsRequired().HasMaxLength(8);
        }
    }
}
