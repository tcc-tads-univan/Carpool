using Carpool.BLL.Services.Campus.Models;
using Carpool.DAL.Persistence.Relational.Repository.Interfaces;

namespace Carpool.BLL.Services.Campus
{
    public class CampusService : ICampusService
    {
        private readonly ICampusRepository _campusRepository;
        public CampusService(ICampusRepository campusRepository)
        {
            _campusRepository = campusRepository;
        }
        public async Task<List<CampusResult>> GetAllCampi()
        {
            var campi = await _campusRepository.GetAllCampi();
            var campusResult = campi.Select(c => new CampusResult
            {
                CampusId = c.CampusId,
                CampusName = c.CampusName,
                CEP = c.CEP,
                LineAddress = c.LineAddress,
                Neighborhood = c.Neighborhood,
                College = new CollegeResult
                {
                    Acronym = c.College.Acronym,
                    CollegeName = c.College.CollegeName
                }
            }).ToList();
            return campusResult;
        }
    }
}
