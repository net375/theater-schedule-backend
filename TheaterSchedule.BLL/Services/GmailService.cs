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

        public async Task<bool> Send(EmailMessageDTO messageDTO)
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
                try
                {
                    //smtp.gmail.com allow us send up to 500 emails per day
                    //port also can be 587
                    await client.ConnectAsync("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                }
                catch (SmtpCommandException ex)
                {
                    LastError = string.Format("Error trying to connect: {0}", ex.Message);
                    LastError += string.Format("\tStatusCode: {0}", ex.StatusCode);
                    return false;
                }
                catch (SmtpProtocolException ex)
                {
                    LastError = string.Format("Protocol error while trying to connect: {0}", ex.Message);
                    return false;
                }               

                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                try
                {
                    // Note: only needed if the SMTP server requires authentication
                    //lpt1.noreply@gmail.com is valid email, with permission for less secure devices
                    await client.AuthenticateAsync("lpt1.noreply@gmail.com", "Lv-375.Net");
                }
                catch (AuthenticationException ex)
                {
                    LastError = string.Format("Invalid user name or password.");
                    return false;
                }
                catch (SmtpCommandException ex)
                {
                    LastError = string.Format("Error trying to authenticate: {0}", ex.Message);
                    LastError += string.Format("\tStatusCode: {0}", ex.StatusCode);
                    return false;
                }
                catch (SmtpProtocolException ex)
                {
                    LastError = string.Format("Protocol error while trying to authenticate: {0}", ex.Message);
                    return false;
                }


                try
                {
                    await client.SendAsync(message);
                }
                catch (SmtpCommandException ex)
                {
                    LastError = string.Format("Error sending message: {0}", ex.Message);
                    LastError += string.Format("\tStatusCode: {0}", ex.StatusCode);

                    switch (ex.ErrorCode)
                    {
                        case SmtpErrorCode.RecipientNotAccepted:
                            LastError += string.Format("\tRecipient not accepted: {0}", ex.Mailbox);
                            break;
                        case SmtpErrorCode.SenderNotAccepted:
                            LastError += string.Format("\tSender not accepted: {0}", ex.Mailbox);
                            break;
                        case SmtpErrorCode.MessageNotAccepted:
                            LastError += string.Format("\tMessage not accepted.");
                            break;
                    }
                }
                catch (SmtpProtocolException ex)
                {
                    LastError = string.Format("Protocol error while sending message: {0}", ex.Message);
                }
                
                await client.DisconnectAsync(true);
            }

            //return true if success
            return string.IsNullOrEmpty(LastError);
        }

    }
}
