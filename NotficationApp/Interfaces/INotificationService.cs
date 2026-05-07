using System;

namespace NotficationApp.Interfaces
{
    public interface INotificationService
    {
        string Name { get; }
        void Send(string message);
    }
}
