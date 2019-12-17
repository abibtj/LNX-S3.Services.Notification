using S3.Common.RabbitMq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;

namespace S3.Services.Notification.Controllers
{
  [Route("")]
    public class HomeController : ControllerBase
    {
       [HttpGet]
        [AllowAnonymous]
        public IActionResult Get() => Ok("Notification service running...");
    }
}
