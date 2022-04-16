using Data;
using Data.Models;
using DesktopApp.Stores;
using Oneironautics.Stores;
using Oneironautics.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oneironautics.Commands
{
    internal class DreamEditorCommands
    {
        internal class SaveDream : CommandBase
        {
            private readonly NavigationStore _navigationStore;
            private readonly JournalStore _journalStore;
            private readonly DreamEditorViewModel _dreamEditorViewModel;

            public SaveDream(DreamEditorViewModel dreamEditorViewModel, 
                                  NavigationStore navigationStore, JournalStore journalStore)
            {
                _dreamEditorViewModel = dreamEditorViewModel;
                _navigationStore = navigationStore;
                _journalStore = journalStore;
            }

            public override void Execute(object? parameter)
            {
                var dream = new Dream()
                {
                    Title = _dreamEditorViewModel.Title,
                    Content = _dreamEditorViewModel.Content,
                    Notes = _dreamEditorViewModel.Notes,
                    DreamDateTime = _dreamEditorViewModel.DreamDateTime,
                    Position = _dreamEditorViewModel.SleepingPosition,
                    Lucidity = _dreamEditorViewModel.LucidityLevel
                };

                _journalStore.AddDream(dream);

                _navigationStore.CurrentViewModel = new DreamListingViewModel(_navigationStore, _journalStore);
            }
        }
    }
}
