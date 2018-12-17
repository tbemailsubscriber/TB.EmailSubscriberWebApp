using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;


namespace TB.EmailSubscriber.EmailDistributor
{
    public class EmailSender: IEmailSender
    {
        private readonly string _serviceUserName;
        private readonly string _servicePassword;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _unsubscribeApiUrl;

        public EmailSender()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var appSetting = root.GetSection("ApplicationSettings");
            _serviceUserName = appSetting["serviceUserName"];
            _servicePassword = appSetting["serviceUserPassword"];
            _smtpServer = appSetting["smtpHost"];
            _smtpPort = Int32.Parse(appSetting["smtpPort"]);
            _unsubscribeApiUrl = appSetting["unsubscribeApiUrl"];
        }
        public void SendConfirmation(string emailAddress, string unsubscribeToken,  string[] topics)
        {
            try
            {
                string unsubscribeLink = _unsubscribeApiUrl + unsubscribeToken;
                MailMessage mailMessage = EmailBuilder.BuildSubscribeMessage(emailAddress, topics, unsubscribeLink);
                Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SendUnsubscribeConfirmation(string emailAddress)
        {
            try
            {
                MailMessage mailMessage = EmailBuilder.BuildUnsubscribeMessage(emailAddress);
                Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Send(MailMessage mailMessage)
        {

            SmtpClient smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential(_serviceUserName, _servicePassword),
                EnableSsl = true,
                Host = _smtpServer,
                Port = _smtpPort
            };
            smtpClient.Send(mailMessage);
        }

        

        
    }
}
