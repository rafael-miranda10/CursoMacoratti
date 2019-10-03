using System.Threading.Tasks;

namespace AspnCore_EnviaEmail.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
