using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DesktopApp.Entities
{
    public class SignCategory : BaseEntity
    {
        [Key]
        public int SignCategoryId { get; set; }
        public string Title { get; set; }
    }
}
