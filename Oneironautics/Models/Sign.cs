using Data.Enums;
using Data.Interfaces;
using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Models
{
    public class Sign : ItemModelBase, ISign
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, nameof(Title)); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value, nameof(Description)); }
        }

        private int _typeId { get; set; }
        public SignType Type
        {
            get { return (SignType)_typeId; }
            set { _typeId = (int)value; }
        }
    }
}
