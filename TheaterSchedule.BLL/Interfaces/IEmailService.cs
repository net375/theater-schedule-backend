using System.Threading.Tasks;

namespace TheaterSchedule.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}