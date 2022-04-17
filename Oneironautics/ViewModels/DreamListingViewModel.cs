using ControlzEx.Theming;
using Data;
using Data.Models;
using DesktopApp.Stores;
using Oneironautics.Commands;
using Oneironautics.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Oneironautics.ViewModels
{
    internal class DreamListingViewModel : ViewModelBase
    {
        public ICommand AddNewDreamAction { get; }
        
        public ObservableCollection<IDream> Dreams { get; } = new ObservableCollection<IDream>();

        public DreamListingViewModel(NavigationStore navigationStore, JournalStore journalStore)
        {
            AddNewDreamAction = new DreamListingCommands.AddNewDream(navigationStore, journalStore);
            
            ShowDreams(journalStore.Dreams);
        }

        private void ShowDreams(IEnumerable<IDream> dreamsFromJournalStore)
        {
            Dreams.Clear();
            foreach (var dream in dreamsFromJournalStore)
            {
                Dreams.Add(dream);
            }
        }
    }
}
