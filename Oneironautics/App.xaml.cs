using Data;
using DesktopApp.Models;
using DesktopApp.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oneironautics.Commands;
using Oneironautics.Stores;
using Oneironautics.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Oneironautics
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
                services.AddSingleton<NavigationStore>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton((s) => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });

                services.AddTransient<DreamListingViewModel>();
            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Configure services
            _host.Start();

            // Set main window view to dream listing view
            var navigationStore = _host.Services.GetRequiredService<NavigationStore>();
            navigationStore.CurrentViewModel = _host.Services.GetRequiredService<DreamListingViewModel>();

            // Show main window
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
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
