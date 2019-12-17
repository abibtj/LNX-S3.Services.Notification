
using FluentValidation;
using S3.Services.Notification.Utility;
using System;

namespace S3.Services.Registration.Students.Commands.Validators
{
    public class SendMailCommandValidator : AbstractValidator<SendMailCommand>
    {
        public SendMailCommandValidator()
        {

        }
    }
}
