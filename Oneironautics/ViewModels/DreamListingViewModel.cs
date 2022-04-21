﻿using ControlzEx.Theming;
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

namespace DesktopApp.ViewModels
{
    internal class DreamListingViewModel : UIElement
    {
        public ICommand AddNewDreamAction { get; }
        public ICommand OpenDreamAction { get; }
        public ICommand SelectionChanged { get; }
        public ICommand DeleteSelectedDream { get; }
        public ICommand KeyPressCommand { get; }        
        public IEnumerable<IDream> SelectedDreams { get; set; }

        public ObservableCollection<IDream> Dreams { get; }
        public DreamListingViewModel(JournalStore journalStore)
        {

            DreamListingCommands.SelectionChangedCommand.SelectionHasChanged += OnSelectionChanged;
            
            SelectionChanged = new DreamListingCommands.SelectionChangedCommand();
            AddNewDreamAction = new DreamListingCommands.AddNewDream(journalStore);
            OpenDreamAction = new DreamListingCommands.OpenDreamEditor(journalStore, this);
            DeleteSelectedDream = new DreamListingCommands.DeleteDream(journalStore, this);
            KeyPressCommand = new DreamListingCommands.KeyPressCommand(journalStore, this);

            Dreams = journalStore.Dreams;
        }

        public void OnSelectionChanged(IEnumerable<IDream> selectedDreams)
        {
            SelectedDreams = selectedDreams;
        }

    }
}
