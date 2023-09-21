using HR.Management.Application.Models.Email;

namespace HR.Management.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailMessage email);
    }
}