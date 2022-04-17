using Oneironautics.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oneironautics.ViewModels;
using DesktopApp.Stores;
using Oneironautics.Views;
using Data.Models;
using System.Windows.Input;

namespace Oneironautics.Commands
{
    internal class DreamListingCommands
    {
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
            private readonly NavigationStore _navigationStore;
            private readonly JournalStore _journalStore;

            public AddNewDream(NavigationStore navigationStore, JournalStore journalStore)
            {
                _navigationStore = navigationStore;
                _journalStore = journalStore;
            }

            public override void Execute(object? parameter)
            {
                var dreamEditorWindow = new DreamEditorView(_navigationStore, _journalStore);
                dreamEditorWindow.Show();
            }
        }

        internal class OpenDreamEditor : CommandBase
        {
            private static NavigationStore? _navigationStore;
            private static JournalStore? _journalStore;
            private DreamListingViewModel _dreamListingViewModel;

            public OpenDreamEditor(NavigationStore navigationStore, JournalStore journalStore, DreamListingViewModel dreamListingViewModel)
            {
                _navigationStore = navigationStore;
                _journalStore = journalStore;
                _dreamListingViewModel = dreamListingViewModel;
            }

            public override void Execute(object? parameter)
            {
                var dreamEditorWindow = new DreamEditorView(_navigationStore, _journalStore, parameter as IDream);
                dreamEditorWindow.Show();
            }
        }
    }
}
