using Oneironautics.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oneironautics.ViewModels;
using DesktopApp.Stores;
using Oneironautics.Views;

namespace Oneironautics.Commands
{
    internal class DreamListingCommands
    {
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

    }
}
