using System.Threading.Tasks;

namespace ListenThen.Domain.Interfaces.Mail
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}