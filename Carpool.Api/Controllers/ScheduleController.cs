using Microsoft.AspNetCore.Mvc;

namespace Carpool.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendPreSchedule()
        {
            await Task.CompletedTask;
            return Ok();
        }

        [HttpPut]
        [Route("accept")]
        public async Task<IActionResult> AcceptSchedule()
        {
            await Task.CompletedTask;
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
