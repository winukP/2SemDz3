using NotficationApp.Interfaces;
using System;

namespace NotficationApp.Classes
{
    public class NotificationSender
    {
        private readonly INotificationService Service;

        public NotificationSender(INotificationService service)
        {
            Service = service;
        }

        public void Send(string message)
        {
            Service.Send(message);
        }
    }
}
