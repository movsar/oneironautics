using Data;
using DesktopApp.Models;
using DesktopApp.Stores;
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
        private readonly NavigationStore _navigationStore;
        private readonly JournalStore _journalStore;
        private readonly Journal _journal;
        public App()
        {
            try
            {
                Storage.Initialize(false);
            }
            catch
            {
                Storage.Initialize(true);
            }

            _journal = new Journal();
            _journalStore = new JournalStore(_journal);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new DreamListingViewModel(_navigationStore, _journalStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };

            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
