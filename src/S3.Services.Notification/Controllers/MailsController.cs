using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using S3.Common.Authentication;
using S3.Common.Dispatchers;
using S3.Common.Mvc;
using S3.Common.RabbitMq;
using S3.Common.Types;
using S3.Services.Notification.Messages.Commands;

namespace S3.Services.Notification.Controllers
{
    //[JwtAuth(Roles = "superadmin, admin")]
    public class MailsController : BaseController
    {
        public MailsController(IBusPublisher busPublisher, IDispatcher dispatcher, ITracer tracer) 
            : base(busPublisher, dispatcher, tracer ) { }

        [HttpPost("send")]
        public async Task<IActionResult> Send(SendMailCommand command)
            => await SendAsync(command, resource: "parent");
    }
}
