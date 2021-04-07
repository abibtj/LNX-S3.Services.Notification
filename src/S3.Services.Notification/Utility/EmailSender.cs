//using Amazon.Runtime;
//using Amazon.SimpleEmail;
//using Amazon.SimpleEmail.Model;
//using Microsoft.AspNetCore.Identity.UI.Services;
//using Microsoft.Extensions.Configuration;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace StudentPortal.Util
//{
//    public class EmailSender : IEmailSender
//    {
//        private readonly IConfiguration _configuration;
//        public EmailSender(IConfiguration configuration)
//            => _configuration = configuration;

//        public async Task SendEmailAsync(string recipientEmail, string subject, string htmlMessage)
//        {
//            var senderEmail = _configuration.GetSection("emailSettings:senderEmail").Value;
//            var accessKey = _configuration.GetSection("emailSettings:accessKey").Value;
//            var secretKey = _configuration.GetSection("emailSettings:secretKey").Value;

//            // Reference: https://docs.aws.amazon.com/sdkfornet/v3/apidocs/items/SimpleEmail/MSimpleEmailServiceSendEmailSendEmailRequest.html
//            var emailRequest = (new SendEmailRequest
//            {
//                Destination = new Destination
//                {
//                    ToAddresses = new List<string> { recipientEmail }
//                },

//                Message = new Message
//                {
//                    Body = new Body
//                    {
//                        Html = new Content
//                        {
//                            Charset = "UTF-8",
//                            Data = htmlMessage
//                        }
//                    },

//                    Subject = new Content
//                    {
//                        Charset = "UTF-8",
//                        Data = subject
//                    }
//                },

//                Source = senderEmail,
//            });

//            AWSCredentials credential = new BasicAWSCredentials(accessKey, secretKey);
//            Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast1; // North Virginia

//            using AmazonSimpleEmailServiceClient client = new AmazonSimpleEmailServiceClient(credential, region);
//            await client.SendEmailAsync(emailRequest);
//        }
//    }
//}



//using Microsoft.AspNetCore.Identity.UI.Services;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;

namespace S3.Services.Notification.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
            => _configuration = configuration;

        public async Task SendEmailAsync(List<string> recipientEmails, string subject, string htmlStringMessage)
        {
            try
            {
                var senderEmail = _configuration.GetSection("emailSettings:senderEmail").Value;
                var senderPassword = _configuration.GetSection("emailSettings:senderPassword").Value;

                var email = new MimeMessage();
                email.From.Add(new MailboxAddress("Test Email...", senderEmail));

                foreach (var recipientEmail in recipientEmails)
                {
                    email.To.Add(new MailboxAddress(recipientEmail, recipientEmail));
                }
                email.Subject = subject;
                // msg.Body = new TextPart("plain")
                email.Body = new TextPart("html")
                {
                    Text = htmlStringMessage
                };

                using var client = new SmtpClient();

                //client.Connect("smtp.gmail.com", 465, false);
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate(senderEmail, senderPassword);
                await client.SendAsync(email);

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