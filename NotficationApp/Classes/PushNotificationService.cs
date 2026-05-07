using NotficationApp.Interfaces;
using System;

namespace NotficationApp.Classes
{
    public class PushNotificationService : INotificationService
    {
        private readonly ILoggerService Logger;
        public string Name { get; } = "Push";

        public PushNotificationService(ILoggerService logger)
        {
            Logger = logger;
        }

        public void Send(string message)
        {
            if (new Random().Next(0, 5) == 0)
                throw new Exception("Сервер не доступен");
            Logger.LogInfo($"Push-уведомление отображено: {message}", Name);
        }
    }
}
