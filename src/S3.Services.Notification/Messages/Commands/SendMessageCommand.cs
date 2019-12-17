using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using S3.Common.Messages;
using System.Collections.Generic;

namespace S3.Services.Registration.Students.Commands
{
    public class SendMailCommand : ICommand
    {
        [Required(ErrorMessage = "Sender's Email is required.")]
        public string SenderEmail { get; }

        [Required(ErrorMessage = "Recipients' Emails is required.")]
        public List<string> RecipientEmails { get; }
        public string? Subject { get; }

        [Required(ErrorMessage = "Message body is required.")]
        public string Body { get; }

        [JsonConstructor]
        public SendMailCommand(string senderEmail, List<string> recipientEmails, string? subject, string body)

            => (SenderEmail, RecipientEmails, Subject, Body)

            = (senderEmail, recipientEmails, subject, body);
    }
}