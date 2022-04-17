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
        public ICommand OpenDreamAction { get; }
        public ICommand SelectionChanged { get; }

        

        public ObservableCollection<IDream> Dreams { get; } = new ObservableCollection<IDream>();
        public IDream SelectedDream { get; set; } 

        public DreamListingViewModel(NavigationStore navigationStore, JournalStore journalStore)
        {
            DreamListingCommands.SelectionChangedCommand.SelectionHasChanged += OnSelectionChanged;
            
            AddNewDreamAction = new DreamListingCommands.AddNewDream(navigationStore, journalStore);
            OpenDreamAction = new DreamListingCommands.OpenDreamEditor(navigationStore, journalStore, this);
            SelectionChanged = new DreamListingCommands.SelectionChangedCommand();
          
            ShowDreams(journalStore.Dreams);
        }

        public void OnSelectionChanged(IDream obj)
        {
            SelectedDream = obj;
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
