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
using System.Windows.Input;

namespace Oneironautics.Commands
{
    internal class DreamEditorCommands
    {
        internal class Save : CommandBase
        {
            private readonly NavigationStore _navigationStore;
            private readonly JournalStore _journalStore;
            private readonly DreamEditorViewModel _dreamEditorViewModel;
            private readonly IDream _dream;

            public Save(NavigationStore navigationStore, JournalStore journalStore, DreamEditorViewModel dreamEditorViewModel, IDream? dream = null)
            {
                _navigationStore = navigationStore;
                _journalStore = journalStore;
                _dreamEditorViewModel = dreamEditorViewModel;
                _dream = dream ?? new Dream();
            }

            public override void Execute(object? parameter)
            {
                _dream.Title = _dreamEditorViewModel.Title;
                _dream.Content = _dreamEditorViewModel.Content;
                _dream.Notes = _dreamEditorViewModel.Notes;
                _dream.DreamDateTime = _dreamEditorViewModel.DreamDateTime;
                _dream.Position = _dreamEditorViewModel.SleepingPosition;
                _dream.Lucidity = _dreamEditorViewModel.LucidityLevel;

                if (_dream.Id != null)
                {
                    _journalStore.UpdateDream(_dream);
                }
                else
                {
                    _journalStore.AddDream(_dream);
                }

                _navigationStore.CurrentViewModel = new DreamListingViewModel(_navigationStore, _journalStore);
            }
        }
    }
}
