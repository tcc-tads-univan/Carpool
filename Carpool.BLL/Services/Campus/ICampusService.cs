using Carpool.BLL.Services.Campus.Models;

namespace Carpool.BLL.Services.Campus
{
    public interface ICampusService
    {
        Task<List<CampusResult>> GetAllCampi(); 
        Task<CampusResult> GetCampus(int campusId); 
    }
}
