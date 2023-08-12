using Carpool.Api.Contracts.Ride.Response;
using Carpool.BLL.Services.Ride;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly IMapper _mapper;

        public StudentController(IRideService rideService, IMapper mapper)
        {
            _rideService = rideService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{studentId}/schedule")]
        public async Task<IActionResult> GetStudentSchedule(int studentId)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
