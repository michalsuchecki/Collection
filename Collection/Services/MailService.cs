using System;
using MailKit;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;

namespace Collection.Services
{
    public class MailService : IMailService
    {
        // TODO: From config
        private readonly MailboxAddress _from;
        private readonly int _smtpPort;
        private readonly string _smtpAdress;
        private readonly string _smtpLogin;
        private readonly string _smtpPassword;
        private readonly X509Certificate2 _certificate;
        private readonly string _serviceAccountEmail;
        private readonly ServiceAccountCredential credential;

        public MailService()
        {
        }

        public async Task SendEmail(string message, string topic, string name, string email)
        {
        }
    }
}
