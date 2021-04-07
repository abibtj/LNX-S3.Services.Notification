using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using S3.Common.Messages;
using System.Collections.Generic;

namespace S3.Services.Notification.Messages.Commands
{
    public class SendMailCommand : ICommand
    {
        // [Required(ErrorMessage = "Sender's Email is required.")]
        // public string SenderEmail { get; }

        [Required(ErrorMessage = "Recipients' Emails is required.")]
        public List<string> RecipientEmails { get; }
        public string? Subject { get; }

        [Required(ErrorMessage = "Message body is required.")]
        public string HtmlStringMessage { get; }

        [JsonConstructor]
        public SendMailCommand(List<string> recipientEmails, string? subject, string htmlStringMessage)

            => (RecipientEmails, Subject, HtmlStringMessage)

            = (recipientEmails, subject, htmlStringMessage);
    }
}