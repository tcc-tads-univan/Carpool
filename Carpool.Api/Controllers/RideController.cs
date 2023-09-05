using Carpool.Api.Contracts.Ride;
using Carpool.Api.Contracts.Ride.Request;
using Carpool.Api.Contracts.Ride.Response;
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
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
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
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> DeleteRideRequest(RideDeleteRequest rideDeleteRequest)
        {
            var command = _mapper.Map<RideDeleteCommand>(rideDeleteRequest);
            var result = await _rideService.CancelStudentRideRequest(command);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return ProblemDetails(result.Errors);
        }
        
        [HttpGet]
        [Route("Campus/{campusId}/Student/{studentId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(RideStudentResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetStudentRide(int campusId, int studentId)
        {
            var rideResult = await _rideService.GetRideRequestByStudent(campusId, studentId);
            if (rideResult.IsSuccess)
            {
                var rideResponse = _mapper.Map<RideStudentResponse>(rideResult.Value);
                return Ok(rideResponse);
            }

            return ProblemDetails(rideResult.Errors);
        }

        [HttpPost]
        [Route("calculate-route")]
        public async Task<IActionResult> CalculateRideRoute(RouteRequest routeRequest)
        {
            //Dependency -> Route Service - GRPC
            await Task.CompletedTask;
            return Ok();
        }


    }
}
