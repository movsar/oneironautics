using Oneironautics.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oneironautics.ViewModels;

namespace Oneironautics.Commands
{
    internal class DreamListingCommands
    {
        internal class AddNewDream : CommandBase
        {
            private readonly NavigationStore _navigationStore;

            public AddNewDream(NavigationStore navigationStore)
            {
                _navigationStore = navigationStore;
            }

            public override void Execute(object? parameter)
            {
                _navigationStore.CurrentViewModel = new DreamEditorViewModel(_navigationStore);
            }
        }

    }
}
