using NotficationApp.Interfaces;
using System;

namespace NotficationApp.Classes
{
    public class EmailService: INotificationService
    {
        private readonly ILoggerService Logger;
        public string Name { get; } = "Email";

        public EmailService(ILoggerService logger)
        {
            Logger = logger;
        }

        public void Send(string message)
        {
            Logger.LogInfo($"Письмо отправлено: {message}", Name);
        }
    }
}
