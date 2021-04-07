
using FluentValidation;
using S3.Services.Notification.Utility;
using System;
using S3.Services.Notification.Messages.Commands;

namespace S3.Services.Registration.Messages.Commands.Validators
{
    public class SendMailCommandValidator : AbstractValidator<SendMailCommand>
    {
        public SendMailCommandValidator()
        {

        }
    }
}
