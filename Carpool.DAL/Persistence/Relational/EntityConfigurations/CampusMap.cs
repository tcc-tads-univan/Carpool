using Carpool.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carpool.DAL.Persistence.Relational.EntityConfigurations
{
    public class CampusMap : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.ToTable("Campus");
            builder.HasKey(c => c.CampusId);
            builder.Property(c => c.CampusName).IsRequired().HasMaxLength(80);
            builder.Property(c => c.LineAddress).IsRequired().HasMaxLength(120);
            builder.Property(c => c.Neighborhood).IsRequired().HasMaxLength(32);
            builder.Property(c => c.CEP).IsRequired().HasMaxLength(10);
        }
    }
}
