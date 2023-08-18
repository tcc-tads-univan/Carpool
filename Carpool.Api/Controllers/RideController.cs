using Carpool.Api.Contracts.Ride;
using Carpool.Api.Contracts.Ride.Request;
using Carpool.BLL.Common.Errors;
using Carpool.BLL.Services.Ride;
using Carpool.BLL.Services.Ride.Models.Command;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carpool.Api.Controllers
{
    [Route("api/[controller]")]
    public class RideController : BaseController
    {
        private readonly IRideService _rideService;
        private readonly IMapper _mapper;
        public RideController(IRideService rideService, IMapper mapper)
        {
            _rideService = rideService;
            _mapper = mapper;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRideRequest(RideCreateRequest rideCreateRequest)
        {
            var command = _mapper.Map<RideCreateCommand>(rideCreateRequest);
            var result = await _rideService.CreateStudentRideRequest(command);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            
            return ProblemDetails(result.Errors);
        }

        [HttpDelete]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteRideRequest(RideDeleteRequest rideDeleteRequest)
        {
            var command = _mapper.Map<RideDeleteCommand>(rideDeleteRequest);
            await _rideService.CancelStudentRideRequest(command);
            return NoContent();
        }

        [HttpPost]
        [Route("calculate-route")]
        public async Task<IActionResult> CalculateRideRoute(RouteRequest routeRequest)
        {
            await Task.CompletedTask;
            return Ok();
        }


    }
}
