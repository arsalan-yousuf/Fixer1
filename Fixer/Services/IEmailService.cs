using Fixer.Models;
namespace Fixer.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailMessage msg);
    }
}
