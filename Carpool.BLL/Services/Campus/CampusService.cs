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
            var campusResult = campi.Select(c => MapToResult(c)).ToList();
            return campusResult;
        }

        public async Task<CampusResult> GetCampus(int campusId)
        {
            var campi = await _campusRepository.GetCampus(campusId);
            return MapToResult(campi);
        }

        private CampusResult MapToResult(DAL.Domain.Campus campi)
        {
            return new CampusResult
            {
                CampusId = campi.CampusId,
                CampusName = campi.CampusName,
                CEP = campi.CEP,
                PlaceId = campi.PlaceId,
                LineAddress = campi.LineAddress,
                Neighborhood = campi.Neighborhood,
                College = new CollegeResult
                {
                    Acronym = campi.College.Acronym,
                    CollegeName = campi.College.CollegeName
                }
            };
        }
    }
}
