using Microsoft.Extensions.DependencyInjection;
using NotficationApp.Classes;
using NotficationApp.Interfaces;

namespace NotficationApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            services.AddSingleton<ILoggerService, AppLogger>();
            services.AddTransient<INotificationService, EmailService>();
            services.AddTransient<INotificationService, SmsService>();
            services.AddTransient<INotificationService, PushNotificationService>();
            services.AddTransient<MainForm>();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}