using Data;
using Data.Models;
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
            private readonly DreamEditorViewModel _dreamEditorViewModel;

            private readonly Dream _dream;

            public SaveDream(DreamEditorViewModel dreamEditorViewModel, NavigationStore navigationStore)
            {
                _dreamEditorViewModel = dreamEditorViewModel;
                _navigationStore = navigationStore;
            }

            public override void Execute(object? parameter)
            {
                Dream dream = new Dream()
                {
                    Title = _dreamEditorViewModel.Title,
                    Content = _dreamEditorViewModel.Content,
                    Notes = _dreamEditorViewModel.Notes,
                    DreamDateTime = _dreamEditorViewModel.DreamDateTime,
                    Position = _dreamEditorViewModel.SleepingPosition,
                    Lucidity = _dreamEditorViewModel.LucidityLevel
                };

                Storage.DreamsRepository.Add(dream);
                
                _navigationStore.CurrentViewModel = new DreamListingViewModel(_navigationStore);
            }
        }
    }
}
