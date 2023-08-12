using Carpool.Api.Contracts.Ride.Response;
using Carpool.BLL.Services.Ride;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampusController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly IMapper _mapper;
        public CampusController(IRideService rideService, IMapper mapper)
        {
            _rideService = rideService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{campusId}/rides")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<RideResponse>))]
        public async Task<IActionResult> GetAllCampusRide(int campusId)
        {
            var rides = await _rideService.GetAllRideRequestsByCampus(campusId);
            var ridesResponse = _mapper.Map<IEnumerable<RideResponse>>(rides);
            return Ok(ridesResponse);
        }
    }
}
