using Data;
using DesktopApp.Models;
using DesktopApp.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DesktopApp.ViewModels;
using DesktopApp.Views;
using System.Windows;

namespace DesktopApp
{
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            Storage storage;
            try
            {
                storage = new Storage(false);
            }
            catch
            {
                storage = new Storage(true);
            }

            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton(storage);
                services.AddSingleton<Journal>();
                services.AddSingleton<JournalStore>();

                services.AddTransient<DreamListingViewModel>();
                
                services.AddSingleton((s) => new DreamListingView()
                {
                    DataContext = s.GetRequiredService<DreamListingViewModel>()
                });

            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Configure services
            _host.Start();

            // Show main window
            MainWindow = _host.Services.GetRequiredService<DreamListingView>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
