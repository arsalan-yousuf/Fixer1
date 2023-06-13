using Fixer.Configuration;
using Fixer.Models;
using Microsoft.Extensions.Options;
using MailKit;
using MailKit.Net.Smtp;
using Microsoft.CodeAnalysis.Options;
using MimeKit;

namespace Fixer.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _setting;
        public EmailService(IOptions<EmailSettings> setting)
        {
            _setting = setting.Value;
        }
        public bool SendEmail(EmailMessage msg)
        {
            var message = new MimeMessage();
            MailboxAddress toaddress = new MailboxAddress(msg.To_Name, msg.To_Email);
            MailboxAddress fromEmail = new MailboxAddress(_setting.FromName, _setting.FromEmail);
            message.To.Add(toaddress);
            message.From.Add(fromEmail);

            message.Subject = msg.Subject;

            BodyBuilder builder = new BodyBuilder();

            //builder.TextBody = $"Dear {msg.To_Name}" + $"Your Account Was Created";
            builder.TextBody = msg.Body;

            message.Body = builder.ToMessageBody();

            var smtp = new SmtpClient();

            ///Real gmail userName *** Real Password
            smtp.Connect(_setting.Host, _setting.Port, MailKit.Security.SecureSocketOptions.Auto);
            smtp.Authenticate(_setting.FromEmail, _setting.Password);

            smtp.Send(message);
            return true;
        }
    }
}
