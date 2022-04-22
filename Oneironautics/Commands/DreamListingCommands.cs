using System;
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
using System.Windows;

namespace DesktopApp.Commands
{
    internal class DreamListingCommands
    {
        private static void OpenDreamEditorAction(Journal journal, JournalStore journalStore, IDream? dream = null)
        {
            var dreamEditorWindow = new DreamEditorView(journal, journalStore, dream);
            dreamEditorWindow.Show();
        }
        private static void DeleteAction(JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
        {
            var result = MessageBox.Show($"Please approva removal of {dreamListingViewModel.SelectedDreams.Count()} dream(s)",
                                             "Confirmation",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                journalStore.DeleteItems(dreamListingViewModel.SelectedDreams);
            }
        }

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
                DeleteAction(_journalStore, _dreamListingViewModel);
            }
        }

        internal class KeyPressCommand : CommandBase
        {
            private readonly JournalStore _journalStore;
            private readonly DreamListingViewModel _dreamListingViewModel;

            public KeyPressCommand(JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {
                _journalStore = journalStore;
                _dreamListingViewModel = dreamListingViewModel;
            }
            public override void Execute(object? parameter)
            {
                var keyEventArgs = parameter as KeyEventArgs;

                if (keyEventArgs!.Key == Key.Delete)
                {
                    DeleteAction(_journalStore, _dreamListingViewModel);
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
                OpenDreamEditorAction(_journal, _journalStore);
            }
        }

        internal class OpenDreamEditor : CommandBase
        {
            private static JournalStore? _journalStore;
            private Journal _journal;

            public OpenDreamEditor(Journal journal, JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {
                _journalStore = journalStore;
                _journal = journal;
            }

            public override void Execute(object? parameter)
            {
                // Get the source where mouse has been clicked, if it's not over a dream, open new dream window
                dynamic eventArgs = parameter as MouseButtonEventArgs;
                var dream = eventArgs!.OriginalSource.DataContext as IDream;

                OpenDreamEditorAction(_journal, _journalStore, dream);
            }
        }
    }
}
