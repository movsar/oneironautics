using Data;
using Data.Interfaces;
using DesktopApp.Models;
using DesktopApp.Stores;
using DesktopApp.ViewModels;
using DesktopApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DesktopApp.Commands
{
    internal class DreamEditorCommands
    {
        internal class EditSign : CommandBase
        {
            private JournalStore _journalStore;

            public EditSign(JournalStore journalStore)
            {
                _journalStore = journalStore;
            }
            public override void Execute(object? parameter)
            {
                var signVm = parameter as SignViewModel;
                var signEditorWindow = new SignEditorView(_journalStore, signVm);
                signEditorWindow.ShowDialog();
            }
        }

        internal class DeleteSign : CommandBase
        {
            private JournalStore _journalStore;
            private DreamEditorViewModel _dreamEditorViewModel;

            public DeleteSign(JournalStore journalStore, DreamEditorViewModel dreamEditorViewModel)
            {
                _journalStore = journalStore;
                _dreamEditorViewModel = dreamEditorViewModel;
            }
            public override void Execute(object? parameter)
            {
                var signVM = parameter as SignViewModel;
                // TODO: Check refs

                var result = MessageBox.Show($"Are you sure you want to delete this sign?",
                                           "Confirmation",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Question);

                var index = _dreamEditorViewModel.Signs.ToList().FindIndex(d => d.Id == signVM.Id);
                _dreamEditorViewModel.Signs.RemoveAt(index);

                if (result == MessageBoxResult.Yes)
                {
                    _journalStore.DeleteSign(signVM);
                }

            }
        }
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
                signEditorWindow.ShowDialog();
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
                if (_dreamEditorViewModel.Content == null || _dreamEditorViewModel.Content.Trim().Length == 0)
                {
                    return;
                }

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
