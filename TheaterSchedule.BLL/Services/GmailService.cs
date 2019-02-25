using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using TheaterSchedule.BLL.DTO;
using TheaterSchedule.BLL.Interfaces;

namespace TheaterSchedule.BLL.Services
{
    public class GmailService : IMailService
    {
        public string LastError { get; set; }

        public GmailService()
        {
        }

        public async Task Send(EmailMessageDTO messageDTO)
        {
            LastError = "";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(messageDTO.SenderName, messageDTO.SenderEmail));
            message.To.Add(new MailboxAddress(messageDTO.RecipientName, messageDTO.RecipientEmail));
            message.Subject = messageDTO.Subject;

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = messageDTO.Content
            };

            using (var client = new SmtpClient())
            {
                //smtp.gmail.com allow us send up to 500 emails per day
                //port also can be 587
                await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                //lpt1.noreply@gmail.com is valid email, with permission for less secure devices
                await client.AuthenticateAsync("lpt1.noreply@gmail.com", "Lv-375.Net");

                await client.SendAsync(message);

                await client.DisconnectAsync(true);
            }
        }

    }
}