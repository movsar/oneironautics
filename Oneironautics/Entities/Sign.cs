using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DesktopApp.Entities
{
    public class Sign : BaseEntity
    {
        [Key]
        public int SignId { get; set; }
        public int SignCategoryId { get; set; }
        public string Title { get; set; }
    }
}
