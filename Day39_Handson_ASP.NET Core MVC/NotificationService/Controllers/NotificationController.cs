using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendNotification(Notification notification)
        {
            return Ok(new
            {
                Message = "Notification sent successfully",
                Data = notification
            });
        }
    }
}