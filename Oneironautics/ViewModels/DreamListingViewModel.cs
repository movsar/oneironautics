using ControlzEx.Theming;
using Data;
using Data.Models;
using DesktopApp.Stores;
using DesktopApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp.ViewModels
{
    internal class DreamListingViewModel : ViewModelBase
    {
        public ICommand AddNewDreamAction { get; }
        public ICommand OpenDreamAction { get; }
        public ICommand SelectionChanged { get; }
        public ICommand DeleteSelectedDream { get; }        
        public IDream SelectedDream { get; set; }

        public ObservableCollection<IDream> Dreams { get; }
        public DreamListingViewModel(JournalStore journalStore)
        {

            DreamListingCommands.SelectionChangedCommand.SelectionHasChanged += OnSelectionChanged;
            
            SelectionChanged = new DreamListingCommands.SelectionChangedCommand();
            AddNewDreamAction = new DreamListingCommands.AddNewDream(journalStore);
            OpenDreamAction = new DreamListingCommands.OpenDreamEditor(journalStore, this);
            DeleteSelectedDream = new DreamListingCommands.DeleteDream(journalStore, this);

            Dreams = journalStore.Dreams;
        }

        public void OnSelectionChanged(IDream obj)
        {
            SelectedDream = obj;
        }

        //private void ShowDreams(IEnumerable<IDream> dreamsFromJournalStore)
        //{
        //    Dreams.Clear();
        //    foreach (var dream in dreamsFromJournalStore)
        //    {
        //        Dreams.Add(dream);
        //    }
        //}

    }
}
