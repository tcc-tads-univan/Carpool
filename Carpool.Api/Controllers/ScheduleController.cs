using Carpool.Api.Contracts.Schedule.Request;
using Carpool.BLL.Services.Schedule;
using Carpool.BLL.Services.Schedule.Models.Command;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<IActionResult> CreatePreSchedule([FromBody] ScheduleCreateRequest scheduleCreateRequest)
        {
            var scheduleCommand = _mapper.Map<ScheduleCreateCommand>(scheduleCreateRequest);
            await _scheduleService.CreatePreSchedule(scheduleCommand);
            return Ok();
        }

        [HttpPut]
        [Route("{scheduleId}/accept")]
        public async Task<IActionResult> AcceptSchedule(int scheduleId)
        {
            await _scheduleService.StudentAcceptSchedule(scheduleId);
            return Ok();
        }

        [HttpPut]
        [Route("reject")]
        public async Task<IActionResult> RejectSchedule()
        {
            await Task.CompletedTask;
            return Ok();
        }

    }
}
