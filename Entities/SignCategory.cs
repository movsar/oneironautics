using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Oneironautics.Entities
{
    public class SignCategory : BaseEntity
    {
        [Key]
        public int SignCategoryId { get; set; }
        public string Title { get; set; }
    }
}
