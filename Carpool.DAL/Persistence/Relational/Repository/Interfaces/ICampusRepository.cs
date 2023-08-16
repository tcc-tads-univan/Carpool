using Carpool.DAL.Domain;

namespace Carpool.DAL.Persistence.Relational.Repository.Interfaces
{
    public interface ICampusRepository 
    {
        Task<IEnumerable<Campus>> GetAllCampi();
        Task<Campus> GetCampus(int campusId);
    }
}
