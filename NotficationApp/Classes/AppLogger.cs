using NotficationApp.Interfaces;
using System;


namespace NotficationApp.Classes
{
    public class AppLogger: ILoggerService
    {
        public event Action<string> OnLogReceived;
        private readonly string Path = @"..\..\..\Logs\log.txt";

        public void LogInfo(string message, string serviceName)
        {
            string fullMsg = $"[{DateTime.Now:HH:mm:ss}] [{serviceName}]: {message}";
            WriteToFile(fullMsg);
        }

        public void LogError(string error)
        {
            string fullMsg = $"[{DateTime.Now:HH:mm:ss}] [ERROR]: {error}";
            WriteToFile(fullMsg);
        }

        public void LogWarning(string message)
        {
            string fullMsg = $"[{DateTime.Now:HH:mm:ss}] [WARNING]: {message}";
            WriteToFile(fullMsg);
        }

        public void LogSecret(string message)
        {
            string fullMsg = $"[{DateTime.Now:HH:mm:ss}] [SECRET]: {message}";
            WriteToFile(fullMsg);
        }

        private void WriteToFile(string text)
        {
            File.AppendAllLines(Path, new[] {text});
            OnLogReceived?.Invoke(text);
        }
    }
}
