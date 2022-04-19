using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DesktopApp.Entities
{
    public class SignToDream : BaseEntity
    {
        [Key]
        public int SignToDreamId { get; set; }
        public int DreamId { get; set; }
        public int SignId { get; set; }
    }
}
