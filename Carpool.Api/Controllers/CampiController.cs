using Carpool.Api.Contracts.Campus.Response;
using Carpool.Api.Contracts.Ride.Response;
using Carpool.BLL.Services.Campus;
using Carpool.BLL.Services.Ride;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampiController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly ICampusService _campusService;
        private readonly IMapper _mapper;
        public CampiController(IRideService rideService, ICampusService campusService, IMapper mapper)
        {
            _rideService = rideService;
            _campusService = campusService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<CampusResponse>))]
        public async Task<IActionResult> GetAllCampi()
        {
            var campi = await _campusService.GetAllCampi();
            var campiResponse = _mapper.Map<List<CampusResponse>>(campi);
            return Ok(campiResponse);
        }

        [HttpGet]
        [Route("{campusId}/ride")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<RideResponse>))]
        public async Task<IActionResult> GetAllCampusRide(int campusId)
        {
            var rides = await _rideService.GetAllRideRequestsByCampus(campusId);
            var ridesResponse = _mapper.Map<List<RideResponse>>(rides);
            return Ok(ridesResponse);
        }
    }
}
