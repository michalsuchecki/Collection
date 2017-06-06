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
            //_from = new MailboxAddress("harukapl@gmail.com");
            //_smtpPort = 587;
            //_smtpAdress = "smtp.gmail.com";
            //_smtpLogin = "harukapl@gmail.com";
            //_smtpPassword = "dupamaryn123";

            //_serviceAccountEmail = "mail-692@api-project-811987209687.iam.gserviceaccount.com";

            //_certificate = new X509Certificate2(@"D:/test.p12", "notasecret", X509KeyStorageFlags.Exportable);

            //credential = new ServiceAccountCredential(
            //   new ServiceAccountCredential.Initializer(_serviceAccountEmail)
            //   {
            //       Scopes = new[] { "https://mail.google.com/" },
            //       User = _smtpLogin
            //   }.FromCertificate(_certificate));
        }

        public async Task SendEmail(string message, string topic, string name, string email)
        {
            //bool result = await credential.RequestAccessTokenAsync(CancellationToken.None);

            //if(true)
            //{
            //    var msg = new MimeMessage()
            //    {
            //        Subject = topic,
            //        Body = new TextPart(TextFormat.Plain)
            //        {
            //            Text = $"{message}"
            //        }
            //    };

            //    msg.From.Add(new MailboxAddress(name, email));
            //    msg.To.Add(_from);

            //    using (var client = new SmtpClient())
            //    {
            //        //client.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //        //client.AuthenticationMechanisms.Remove("XOAUTH2");

            //        await client.ConnectAsync(_smtpAdress, _smtpPort);
            //        await client.AuthenticateAsync(_smtpLogin, credential.Token.AccessToken);

            //        await client.SendAsync(msg);
            //        await client.DisconnectAsync(true);
            //    }
            //}
        }
    }
}
