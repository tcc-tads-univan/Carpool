using Carpool.Api.Contracts.Ride.Response;
using Carpool.Api.Contracts.Schedule.Response;
using Carpool.BLL.Services.Ride;
using Carpool.BLL.Services.Schedule;
using Carpool.BLL.Services.Schedule.Models.Result;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class StudentController : ControllerBase
    {
        private readonly IRideService _rideService;
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;

        public StudentController(IRideService rideService, IScheduleService scheduleService, IMapper mapper)
        {
            _rideService = rideService;
            _scheduleService = scheduleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Student/{studentId}/schedule")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ScheduleResponse))]
        public async Task<IActionResult> GetStudentSchedule(int studentId)
        {
            var scheduleResult = await _scheduleService.GetStudentPreSchedule(studentId);
            var scheduleResponse = _mapper.Map<ScheduleResponse>(scheduleResult);
            return Ok(scheduleResponse);
        }

        [HttpGet]
        [Route("Campus/{campusId}/Student/{studentId}/ride")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(RideResponse))]
        public async Task<IActionResult> GetStudentRide(int campusId, int studentId)
        {
            var ride = await _rideService.GetRideRequestByStudent(campusId, studentId);
            var rideResponse = _mapper.Map<RideStudentResponse>(ride);
            return Ok(rideResponse);
        }
    }
}
