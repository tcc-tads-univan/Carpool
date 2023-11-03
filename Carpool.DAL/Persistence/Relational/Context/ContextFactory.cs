using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Carpool.DAL.Persistence.Relational.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<CarpoolContext>
    {
        public CarpoolContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarpoolContext>();
            optionsBuilder.UseSqlServer("Server=tcp:tccunivanfinal.database.windows.net,1433;Initial Catalog=carpool-service;Persist Security Info=False;User ID=tccunivan;Password=Project!123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new CarpoolContext(optionsBuilder.Options);
        }
    }
}
