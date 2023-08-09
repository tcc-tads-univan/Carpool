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
        public async Task<IActionResult> CreateRideRequest(RideRequest rideRequest)
        {
            await Task.CompletedTask;
            //Mapping rideRequest to rideCommand
            //Service -> get information from student microservice
            //_rideService.CreateStudentRideRequest();
            //Populate Ride Domain Model
            //Call rideRepository to save
            return Ok();
        }
    }
}
