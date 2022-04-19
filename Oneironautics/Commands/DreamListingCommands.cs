using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.ViewModels;
using DesktopApp.Stores;
using DesktopApp.Views;
using Data.Models;
using System.Windows.Input;

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
                _journalStore.DeleteDream(parameter as IDream);
            }
        }

        internal class SelectionChangedCommand : CommandBase
        {
            public static event Action<IDream>? SelectionHasChanged;

            public override void Execute(object? parameter)
            {
                SelectionHasChanged?.Invoke(parameter as IDream);
            }
        }

        internal class AddNewDream : CommandBase
        {
            private readonly JournalStore _journalStore;

            public AddNewDream(JournalStore journalStore)
            {
                
                _journalStore = journalStore;
            }

            public override void Execute(object? parameter)
            {
                var dreamEditorWindow = new DreamEditorView(_journalStore);
                dreamEditorWindow.Show();
            }
        }

        internal class OpenDreamEditor : CommandBase
        {
            private static JournalStore? _journalStore;
            private DreamListingViewModel _dreamListingViewModel;

            public OpenDreamEditor(JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {
                
                _journalStore = journalStore;
                _dreamListingViewModel = dreamListingViewModel;
            }

            public override void Execute(object? parameter)
            {
                var dreamEditorWindow = new DreamEditorView(_journalStore, parameter as IDream);
                dreamEditorWindow.Show();
            }
        }
    }
}
