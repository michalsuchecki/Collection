using System;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Collection.Services
{
    public class MailService : IMailService
    {
        public MailService()
        {
        }

        public async Task SendEmail(string message, string topic, string name, string email)
        {
            await Task.CompletedTask;
        }
    }
}
