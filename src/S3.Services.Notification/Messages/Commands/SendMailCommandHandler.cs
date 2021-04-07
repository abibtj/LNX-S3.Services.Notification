using System.Threading.Tasks;
using S3.Common.Handlers;
using S3.Common.RabbitMq;
using S3.Common.Types;
using S3.Services.Notification.Domain;
using Microsoft.Extensions.Logging;
using S3.Common;
using System;
using Microsoft.EntityFrameworkCore;
using S3.Services.Notification.Utility;

namespace S3.Services.Notification.Messages.Commands
{
    public class SendMailCommandHandler : ICommandHandler<SendMailCommand>
    {
        private readonly IBusPublisher _busPublisher;
        private readonly ILogger<SendMailCommandHandler> _logger;
        private readonly NotificationDbContext _db;
        private readonly IEmailSender _emailSender;

        public SendMailCommandHandler(IBusPublisher busPublisher, ILogger<SendMailCommandHandler> logger,
        NotificationDbContext db, IEmailSender emailSender)
            => (_busPublisher, _logger, _db, _emailSender) = (busPublisher, logger, db, emailSender);


        public async Task HandleAsync(SendMailCommand command, ICorrelationContext context)
        {
            await _emailSender.SendEmailAsync(command.RecipientEmails, command.Subject, command.HtmlStringMessage);
        }
    }
}