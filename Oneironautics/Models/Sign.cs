using Data.Enums;
using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Interfaces
{
    public class Sign : ItemModelBase, ISign
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SignType Type { get; set; }     
    }
}
