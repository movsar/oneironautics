﻿using Data;
using Data.Models;
using DesktopApp.Models;
using DesktopApp.Stores;
using DesktopApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.Commands
{
    internal class DreamEditorCommands
    {
        internal class Close : CommandBase
        {
            private readonly WindowActions _dreamEditorWindowActions;

            public Close(WindowActions dreamEditorWindowActions)
            {
                _dreamEditorWindowActions = dreamEditorWindowActions;
            }

            public override void Execute(object? parameter)
            {
                _dreamEditorWindowActions.CLose();
            }
        }

        internal class Save : CommandBase
        {
            private readonly JournalStore _journalStore;
            private readonly DreamEditorViewModel _dreamEditorViewModel;
            private readonly IDream _dream;
            private readonly WindowActions _dreamEditorWindowActions;

            public Save(JournalStore journalStore, WindowActions dreamEditorWindowActions, DreamEditorViewModel dreamEditorViewModel, IDream? dream = null)
            {
                
                _journalStore = journalStore;
                _dreamEditorViewModel = dreamEditorViewModel;
                _dream = dream ?? new Dream();
                _dreamEditorWindowActions = dreamEditorWindowActions;
            }

            public override void Execute(object? parameter)
            {
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

                _dreamEditorWindowActions.CLose();
            }
        }
    }
}
