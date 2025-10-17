
using System.Net;
using System.Net.Mail;

namespace Tekever_Challenge.EmailService
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = "acastanhotekchall@gmail.com";
            var pass = "tJ2Wbf3FA@4@M4M8";

            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pass)
            };

            return client.SendMailAsync(
                new MailMessage(from: mail,
                to: email,
                subject,
                message)
                );
        }
    }
}
