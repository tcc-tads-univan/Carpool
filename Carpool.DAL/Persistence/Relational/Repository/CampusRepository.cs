using Carpool.DAL.Domain;
using Carpool.DAL.Persistence.Relational.Context;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Carpool.DAL.Persistence.Relational.Repository
{
    public class CampusRepository : ICampusRepository
    {
        private readonly DbSet<Campus> _campusEntity;
        public CampusRepository(CarpoolContext context, ILogger<CampusRepository> logger)
        {
            _campusEntity = context.Set<Campus>();
        }
        public async Task<IEnumerable<Campus>> GetAllCampi()
        {
            return await _campusEntity.Include(c => c.College).ToListAsync();
        }
    }
}
