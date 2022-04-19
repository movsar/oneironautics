using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Interfaces
{
    public class SignToDream //: ModelBase
    {
        public string SignToDreamId { get; set; }
        public string DreamId { get; set; }
        public string SignId { get; set; }
    }
}
