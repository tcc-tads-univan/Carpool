using Carpool.Api.Contracts.Schedule.Request;
using Carpool.Api.Contracts.Schedule.Response;
using Carpool.BLL.Services.Schedule;
using Carpool.BLL.Services.Schedule.Models.Command;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carpool.Api.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : BaseController
    {
        private readonly IScheduleService _scheduleService;
        private readonly IMapper _mapper;
        public ScheduleController(IScheduleService scheduleService, IMapper mapper)
        {
            _scheduleService = scheduleService;
            _mapper = mapper; 
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> CreatePreSchedule(ScheduleCreateRequest scheduleCreateRequest)
        {
            var scheduleCommand = _mapper.Map<ScheduleCreateCommand>(scheduleCreateRequest);
            var result = await _scheduleService.CreatePreSchedule(scheduleCommand);
            if (result.IsSuccess)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return ProblemDetails(result.Errors);
        }

        [HttpPut]
        [Route("{scheduleId}/accept")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> AcceptSchedule(int scheduleId)
        {
            var result = await _scheduleService.StudentAcceptSchedule(scheduleId);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return ProblemDetails(result.Errors);
        }

        [HttpPut]
        [Route("{scheduleId}/reject")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> RejectSchedule(int scheduleId)
        {
            var result = await _scheduleService.StudentRejectSchedule(scheduleId);
            if (result.IsSuccess)
            {
                return NoContent();
            }

            return ProblemDetails(result.Errors);
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ScheduleResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetScheduleByStudentId([FromQuery] int studentId)
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
        [Route("{scheduleId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ScheduleResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetSchedule(int scheduleId)
        {
            var scheduleResult = await _scheduleService.GetSchedule(scheduleId);
            if (scheduleResult.IsSuccess)
            {
                var scheduleResponse = _mapper.Map<ScheduleResponse>(scheduleResult.Value);
                return Ok(scheduleResponse);
            }

            return ProblemDetails(scheduleResult.Errors);
        }

    }
}
