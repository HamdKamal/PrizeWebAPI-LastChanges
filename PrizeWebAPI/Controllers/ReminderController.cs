using Application.Features.Forms.Commands.FormSubmissions.SendReminderEmails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PrizeWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ReminderController(ISendReminderEmailsCommandHandler sendReminderEmailsHandler) : ControllerBase
    {
        private readonly ISendReminderEmailsCommandHandler _sendReminderEmailsHandler = sendReminderEmailsHandler;

        [HttpPost]
        public async Task<IActionResult> SendReminderEmails([FromQuery] DateTime deadline)
        {
            try
            {
                int count = await _sendReminderEmailsHandler.HandleAsync(deadline);
                return Ok(new { Success = true, Message = $"{count} reminder(s) sent.", Count = count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Success = false, Message = "An error occurred while sending reminders.", Error = ex.Message });
            }
        }
    }
}