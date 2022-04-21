using Data.Enums;
using Data.Interfaces;
using DesktopApp.Commands;
using DesktopApp.Models;
using DesktopApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.ViewModels
{
    public class SignEditorViewModel : UiElementBase
    {
        public ICommand Save { get; }
        public IEnumerable<string> SignTypes { get; set; } = Enum.GetNames(typeof(SignType));

        internal SignEditorViewModel(JournalStore journalStore, WindowActions windowActions, ISign? sign)
        {
            Save = new SignEditorCommands.Save(journalStore, this, windowActions, sign);
        }

        private string _title = "";
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                SetProperty(ref _title, value, nameof(Title));
            }
        }

        private string _description = "";
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                SetProperty(ref _description, value, nameof(Description));
            }
        }

        private SignType _signType;
        public SignType SignType
        {
            get { return _signType; }
            set
            {
                _signType = value;
                SetProperty(ref _signType, value, nameof(SignType));
            }
        }

    }
}
