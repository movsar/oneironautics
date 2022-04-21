using Data;
using Data.Interfaces;
using DesktopApp.Models;
using DesktopApp.Stores;
using DesktopApp.ViewModels;
using DesktopApp.Views;
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
        internal class AddNewSign : CommandBase
        {
            private JournalStore _journalStore;

            public AddNewSign(JournalStore journalStore)
            {
                _journalStore = journalStore;
            }
            public override void Execute(object? parameter)
            {
                var signEditorWindow = new SignEditorView(_journalStore);
                signEditorWindow.Show();
            }
        }
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
            private readonly Journal _journal;

            public Save(Journal journal, JournalStore journalStore, WindowActions dreamEditorWindowActions, DreamEditorViewModel dreamEditorViewModel, IDream? dream = null)
            {

                _journalStore = journalStore;
                _dreamEditorViewModel = dreamEditorViewModel;
                _dream = dream ?? new Dream();
                _dreamEditorWindowActions = dreamEditorWindowActions;
                _journal = journal;
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
                    _journalStore.UpdateItem<IDream>(_dream);
                }
                else
                {
                    _journalStore.AddItem<IDream>(_dream);
                }

                _journal.AssociateSignsWithDream(_dream.Id, _dreamEditorViewModel.Signs.Where(sign => sign.IsChecked == true).Select(sign => sign.Id));

                _dreamEditorWindowActions.CLose();
            }
        }
    }
}
