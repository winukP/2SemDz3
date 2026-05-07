using NotficationApp.Interfaces;
using System;

namespace NotficationApp.Classes
{
    public class SmsService : INotificationService
    {
        private readonly ILoggerService Logger;
        public string Name { get; } = "SMS";

        public SmsService(ILoggerService logger)
        {
            Logger = logger;
        }

        public void Send(string message)
        {
            Logger.LogInfo($"SMS доставлено: {message}", Name);
        }
    }
}
