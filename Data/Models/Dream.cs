using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using MongoDB.Bson;
using Data.Enums;

namespace Data.Models
{
    public class Dream : ModelBase, IDream
    {
        public int Index { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Notes { get; set; }
        public DateTimeOffset DreamDateTime { get; set; }
        public LucidityLevel Lucidity { get; set; }
        public SleepingPosition Position { get; set; }
        public IList<string> AssociatedSignIds { get; set; }
    }
}
