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

namespace DesktopApp.Commands
{
    public class SignEditorCommands
    {
        internal class Save : CommandBase
        {
            private readonly JournalStore _journalStore;
            private readonly SignEditorViewModel _signEditorViewModel;
            private readonly ISign _sign;
            private WindowActions _windowActions;

            public Save(JournalStore journalStore, SignEditorViewModel signEditorViewModel, WindowActions windowActions, ISign? sign = null)
            {
                _journalStore = journalStore;
                _windowActions= windowActions;
                _signEditorViewModel = signEditorViewModel;
                _sign = sign ?? new Sign();
            }

            public override void Execute(object? parameter)
            {
                _sign.Title = _signEditorViewModel.Title;
                _sign.Description = _signEditorViewModel.Description;
                _sign.Type = _signEditorViewModel.SignType;

                if (_sign.Id != null)
                {
                    _journalStore.UpdateItem<ISign>(_sign);
                }
                else
                {
                    _journalStore.AddItem<ISign>(_sign);
                }

                _windowActions.CLose();
            }
        }
    }
}
