using Carpool.BLL.Services.Campus.Models;

namespace Carpool.BLL.Services.Campus
{
    public interface ICampusService
    {
        Task<IEnumerable<CampusResult>> GetAllCampi(); 
    }
}
