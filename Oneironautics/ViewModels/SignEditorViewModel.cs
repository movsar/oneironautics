using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopApp.ViewModels
{
    public class SignEditorViewModel : ViewModelBase
    {
        public ICommand Save { get; }

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
                OnPropertyChanged(nameof(Title));
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
                OnPropertyChanged(nameof(Description));
            }
        }

        private SignType _signType;
        public SignType SignType
        {
            get { return _signType; }
            set
            {
                _signType = value;
                OnPropertyChanged(nameof(SignType));
            }
        }

    }
}
