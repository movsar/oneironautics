using Data.Enums;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Models
{
    public class Sign : ModelBase, ISign
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public SignType Type { get; set; }
    }
}
