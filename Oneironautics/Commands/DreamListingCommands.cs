﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ViewModels;
using DesktopApp.Stores;
using DesktopApp.Views;
using Data.Interfaces;
using System.Windows.Input;
using System.Windows.Controls;
using DesktopApp.Models;

namespace DesktopApp.Commands
{
    internal class DreamListingCommands
    {
        internal class DeleteDream : CommandBase
        {
            private readonly JournalStore _journalStore;
            private readonly DreamListingViewModel _dreamListingViewModel;

            public DeleteDream(JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {

                _journalStore = journalStore;
                _dreamListingViewModel = dreamListingViewModel;
            }

            public override void Execute(object? parameter)
            {
                _journalStore.DeleteItems(_dreamListingViewModel.SelectedDreams);
            }
        }

        internal class KeyPressCommand : CommandBase
        {
            private JournalStore _journalStore;
            private DreamListingViewModel _dreamListingViewModel;

            public KeyPressCommand(JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {
                _journalStore = journalStore;
                _dreamListingViewModel = dreamListingViewModel;
            }
            public override void Execute(object? parameter)
            {
                var keyEventArgs = parameter as KeyEventArgs;

                switch (keyEventArgs.Key)
                {
                    case Key.Delete:
                        _journalStore.DeleteItems(_dreamListingViewModel.SelectedDreams);

                        break;
                    default:
                        return;
                }
            }
        }

        internal class SelectionChangedCommand : CommandBase
        {
            public static event Action<IEnumerable<IDream>>? SelectionHasChanged;

            public override void Execute(object? parameter)
            {
                var selectedItems = parameter as System.Collections.IList;

                SelectionHasChanged?.Invoke(selectedItems.Cast<IDream>());
            }
        }

        internal class AddNewDream : CommandBase
        {
            private readonly Journal _journal;
            private readonly JournalStore _journalStore;

            public AddNewDream(Journal journal, JournalStore journalStore)
            {
                _journal = journal;
                _journalStore = journalStore;
            }

            public override void Execute(object? parameter)
            {
                var dreamEditorWindow = new DreamEditorView(_journal, _journalStore);
                dreamEditorWindow.Show();
            }
        }

        internal class OpenDreamEditor : CommandBase
        {
            private static JournalStore? _journalStore;
            private Journal _journal;
            private DreamListingViewModel _dreamListingViewModel;

            public OpenDreamEditor(Journal journal, JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {

                _journalStore = journalStore;
                _journal = journal;
                _dreamListingViewModel = dreamListingViewModel;
            }

            public override void Execute(object? parameter)
            {
                var dreamEditorWindow = new DreamEditorView(_journal, _journalStore, parameter as IDream);
                dreamEditorWindow.Show();
            }
        }
    }
}
