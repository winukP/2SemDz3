using System;

namespace NotficationApp.Interfaces
{
    public interface ILoggerService
    {
        void LogInfo(string message, string serviceName);
        void LogError(string error);
        void LogWarning(string message);
        void LogSecret(string message);
        event Action<string> OnLogReceived;
    }
}
