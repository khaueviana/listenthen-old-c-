using ListenThen.Domain.Interfaces.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ListenThen.Infra.CrossCutting.Messaging.Mail
{
    public class EmailSender : IEmailSender
    {
        private string sendGridKey;

        public EmailSender()
        {
            sendGridKey = "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";
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(subject, message, email);
        }
        private Task Execute(string subject, string message, string email)
        {
            var client = new SendGridClient(sendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("khaueviana@gmail.com", "Khauê Viana"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}