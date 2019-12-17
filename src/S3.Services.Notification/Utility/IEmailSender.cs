//using Microsoft.AspNetCore.Identity.UI.Services;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Threading.Tasks;
using System.Collections.Generic;

//using System.Net;
//using System.Net.Mail;
//using SmtpClient = System.Net.Mail.SmtpClient;
//using Amazon.Runtime;

// using Amazon.Runtime;
// using Amazon.SimpleEmail;
// using Amazon.SimpleEmail.Model;
// using Microsoft.AspNetCore.Identity.UI.Services;
// using System.Collections.Generic;
// using System.Threading.Tasks;

namespace S3.Services.Notification.Utility
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string senderEmail, List<string> recipientEmails, string subject, string htmlMessage);
    }
}
