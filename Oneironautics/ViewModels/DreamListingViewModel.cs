using ControlzEx.Theming;
using Data;
using Data.Interfaces;
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
using DesktopApp.Models;
using Data.Models;

namespace DesktopApp.ViewModels
{
    internal class DreamListingViewModel : ViewModelBase
    {
        public ICommand AddNewDreamAction { get; }
        public ICommand OpenDreamAction { get; }
        public ICommand SelectionChanged { get; }
        public ICommand DeleteSelectedDream { get; }
        public ICommand KeyPressCommand { get; }        
        
        public ObservableCollection<DreamViewModel> Dreams { get; }
        public IEnumerable<DreamViewModel> SelectedDreams { get; set; }
        
        public DreamListingViewModel(JournalStore journalStore)
        {
            DreamListingCommands.SelectionChangedCommand.SelectionHasChanged += OnSelectionChanged;
            
            SelectionChanged = new DreamListingCommands.SelectionChangedCommand();
            AddNewDreamAction = new DreamListingCommands.AddNewDream(journalStore);
            OpenDreamAction = new DreamListingCommands.OpenDreamEditor(journalStore, this);
            DeleteSelectedDream = new DreamListingCommands.DeleteDream(journalStore, this);
            KeyPressCommand = new DreamListingCommands.KeyPressCommand(journalStore, this);

            Dreams = new ObservableCollection<DreamViewModel>();
            foreach (var dream in journalStore.Dreams)
            {
                Dreams.Add(new DreamViewModel(dream));
            }

            journalStore.ItemAdded += OnDreamAdded;
            journalStore.ItemUpdated += OnDreamUpdated;
            journalStore.ItemDeleted += OnDreamRemoved;
        }
        public void OnSelectionChanged(IEnumerable<DreamViewModel> selectedDreamVms)
        {
            SelectedDreams = selectedDreamVms;
        }

        private void OnDreamAdded(IModelBase model)
        {
            if (model.GetType().IsAssignableTo(typeof(IDream)) == false) return;

            var dream = model as IDream;
            Dreams.Add(new DreamViewModel(dream));
        }

        private void OnDreamUpdated(IModelBase model)
        {
            if (model.GetType().IsAssignableTo(typeof(IDream)) == false) return;

            var dream = model as IDream;
            var index = Dreams.ToList().FindIndex(d => d.DreamId == dream!.Id);
            Dreams[index] = new DreamViewModel(dream);
        }

        private void OnDreamRemoved(IModelBase model)
        {
            if (model.GetType().IsAssignableTo(typeof(IDream)) == false) return;

            var dream = model as IDream;
            var index = Dreams.ToList().FindIndex(d => d.DreamId == dream!.Id);
            Dreams.RemoveAt(index);
        }
    }
}
