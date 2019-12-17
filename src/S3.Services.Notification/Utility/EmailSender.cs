//using Microsoft.AspNetCore.Identity.UI.Services;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace S3.Services.Notification.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string senderEmail, List<string> recipientEmails, string subject, string htmlMessage)
        {
            try
            {
                var msg = new MimeMessage();
                msg.From.Add(new MailboxAddress("Some heading...", senderEmail));
                msg.To.Add(new MailboxAddress("sender name", senderEmail));
                msg.Subject = subject;
                // msg.Body = new TextPart("plain")
                msg.Body = new TextPart("html")
                {
                    Text = htmlMessage
                };

                using var client = new SmtpClient();

                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(senderEmail, "tj.53545516");
                await client.SendAsync(msg);

                await client.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}