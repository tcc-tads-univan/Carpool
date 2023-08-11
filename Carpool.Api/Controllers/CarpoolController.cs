using Carpool.Api.Contracts.Ride;
using Carpool.BLL.Services.Ride;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarpoolController : ControllerBase
    {
        private readonly IRideService _rideService;
        public CarpoolController(IRideService rideService)
        {
            _rideService = rideService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRideRequest(RideCreateRequest rideCreateRequest)
        {
            await Task.CompletedTask;
            //Mapping rideRequest to rideCommand
            //Service -> get information from student microservice
            //_rideService.CreateStudentRideRequest();
            //Populate Ride Domain Model
            //Call rideRepository to save
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRideRequest(RideDeleteRequest rideDeleteRequest)
        {
            //await _rideService.CancelStudentRideRequest();
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CalculateRideRoute(RouteRequest routeRequest)
        {
            await Task.CompletedTask;
            return Ok();
        }


    }
}
