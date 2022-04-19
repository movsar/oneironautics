using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using MongoDB.Bson;
using Data.Interfaces;
using Data.Enums;

namespace DesktopApp.Models
{
    public class Dream : ItemModelBase, IDream
    {
        public int Index { get; set; }
        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value, nameof(Content)); }
        }

        public string Notes { get; set; }
        public DateTimeOffset DreamDateTime { get; set; }

        private int LucidityId { get; set; }
        public LucidityLevel Lucidity
        {
            get { return (LucidityLevel)LucidityId; }
            set { LucidityId = (int)value; }
        }

        private int PositionId { get; set; }
        public SleepingPosition Position
        {
            get { return (SleepingPosition)PositionId; }
            set { PositionId = (int)value; }
        }
    }
}
