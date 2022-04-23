 using Data;
using Data.Interfaces;
using Data.Models;
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
                var signViewModel = parameter as SignViewModel;

                var signEditorWindow = new SignEditorView(_journalStore, signViewModel?.SignId!);
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
                var signViewModel = parameter as SignViewModel;
                var sign = _journalStore.Signs.Where(sign => sign.Id == signViewModel?.SignId).First();

                // TODO: Check refs
                var result = MessageBox.Show($"Are you sure you want to delete this sign?",
                                           "Confirmation",
                                           MessageBoxButton.YesNo,
                                           MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _journalStore.DeleteItem(sign);
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
            public override void Execute(object? parameter)
            {
                CloseCurrentWindow();
            }
        }

        internal class Save : CommandBase
        {
            private readonly JournalStore _journalStore;
            private readonly DreamEditorViewModel _dreamEditorViewModel;
            private readonly IDream _dream;

            public Save(JournalStore journalStore, DreamEditorViewModel dreamEditorViewModel, IDream? dream = null)
            {
                _journalStore = journalStore;
                _dreamEditorViewModel = dreamEditorViewModel;
                _dream = dream ?? new Dream();
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
                _dream.AssociatedSignIds = _dreamEditorViewModel.Signs.Where(sign => sign.IsSelected == true).Select(sign => sign.SignId).ToList();

                if (_dream.Id != null)
                {
                    _journalStore.UpdateItem<ISign>(_dream);
                }
                else
                {
                    _journalStore.AddItem<ISign>(_dream);
                }

                CloseCurrentWindow();
            }
        }
    }
}
