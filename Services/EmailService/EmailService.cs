using ZNSTLibrary.Services.Users;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace ZNSTLibrary.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public bool SendMail(MailData mailData)
        {
            string to = mailData.EmailToId; //To address    
            string from = _mailSettings.SenderEmail; //From address    
            MailMessage message = new MailMessage(from, to);

            // string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = mailData.EmailSubject;
            message.Body = mailData.EmailBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(_mailSettings.Server, _mailSettings.Port); //Gmail smtp    
            NetworkCredential basicCredential1 = new
            NetworkCredential(_mailSettings.UserName, _mailSettings.Password);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
