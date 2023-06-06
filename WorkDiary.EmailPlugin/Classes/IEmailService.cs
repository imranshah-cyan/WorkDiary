using EmailPlugin.Models;

namespace EmailPlugin.Classes
{
    public interface IEmailService
    {
        bool SendEmail(EmailInfo emailInfo);
    }
}
