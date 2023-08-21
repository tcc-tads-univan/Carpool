using Carpool.Api.Contracts.Ride.Response;
using Carpool.Api.Contracts.Schedule.Response;
using Carpool.BLL.Services.Ride;
using Carpool.BLL.Services.Schedule;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carpool.Api.Controllers
{
    [Route("api")]
    public class StudentController : BaseController
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
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetStudentSchedule(int studentId)
        {
            var scheduleResult = await _scheduleService.GetStudentPreSchedule(studentId);
            if (scheduleResult.IsSuccess)
            {
                var scheduleResponse = _mapper.Map<ScheduleResponse>(scheduleResult.Value);
                return Ok(scheduleResponse);
            }

            return ProblemDetails(scheduleResult.Errors);
        }

        [HttpGet]
        [Route("Campi/{campusId}/Student/{studentId}/ride")]
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
    }
}
