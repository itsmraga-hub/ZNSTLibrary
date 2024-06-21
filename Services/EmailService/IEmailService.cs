using ZNSTLibrary.Services.Users;

namespace ZNSTLibrary.Services.EmailService
{
    public interface IEmailService
    {
        bool SendMail(MailData mailData);
    }
}
