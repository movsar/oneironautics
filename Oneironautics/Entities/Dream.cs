using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Oneironautics.Entities
{
    public enum SleepingPosition
    {
        Unknown,
        Right,
        Back,
        Left,
        Stomach
    }

    public class Dream : BaseEntity
    {
        [Key]
        public int DreamId { get; set; }
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public string Notes { get; set; }
        [Range(0, 4)] public int Clarity { get; set; }
        [Range(0, 4)] public int Awareness { get; set; }
        public SleepingPosition Position { get; set; }
    }
}
