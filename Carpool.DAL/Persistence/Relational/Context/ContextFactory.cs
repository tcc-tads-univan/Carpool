using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Carpool.DAL.Persistence.Relational.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<CarpoolContext>
    {
        public CarpoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarpoolContext>();
            optionsBuilder.UseSqlServer("");
            return new CarpoolContext(optionsBuilder.Options);
        }
    }
}
