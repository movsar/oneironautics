using Data.Enums;
using Data.Interfaces;
using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.ViewModels
{
    internal class SignViewModel : ViewModelBase
    {
        private readonly ISign _sign;
        public SignViewModel(ISign sign, bool isSelected)
        {
            _sign = sign;
            IsSelected = isSelected;
        }
        public string SignId => _sign.Id;
        public string Title => _sign.Title;
        public string Description => _sign.Description;
        public SignType SignType => _sign.Type;
        public bool IsSelected { get; set; }
    }
}
