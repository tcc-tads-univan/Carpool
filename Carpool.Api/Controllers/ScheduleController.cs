using Carpool.Api.Contracts.Schedule.Request;
using Carpool.Api.Contracts.Schedule.Response;
using Carpool.BLL.Services.Schedule;
using Carpool.BLL.Services.Schedule.Models.Command;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
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
        public async Task<IActionResult> CreatePreSchedule(ScheduleCreateRequest scheduleCreateRequest)
        {
            var scheduleCommand = _mapper.Map<ScheduleCreateCommand>(scheduleCreateRequest);
            await _scheduleService.CreatePreSchedule(scheduleCommand);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Route("{scheduleId}/accept")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AcceptSchedule(int scheduleId)
        {
            await _scheduleService.StudentAcceptSchedule(scheduleId);
            return Ok();
        }

        [HttpPut]
        [Route("{scheduleId}/reject")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RejectSchedule(int scheduleId)
        {
            await _scheduleService.StudentRejectSchedule(scheduleId);
            return Ok();
        }

        [HttpGet]
        [Route("{scheduleId}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ScheduleResponse))]
        public async Task<IActionResult> GetSchedule(int scheduleId)
        {
            var scheduleResult = await _scheduleService.GetSchedule(scheduleId);
            var scheduleResponse = _mapper.Map<ScheduleResponse>(scheduleResult);
            return Ok(scheduleResponse);
        }

    }
}
