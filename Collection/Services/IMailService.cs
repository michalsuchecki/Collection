using System.Threading.Tasks;

namespace Collection.Services
{
    public interface IMailService
    {
        Task SendEmail(string message, string topic, string name, string email);
    }
}
