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

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value, nameof(Notes)); }
        }

        private DateTimeOffset _dreamDateTime;
        public DateTimeOffset DreamDateTime
        {
            get { return _dreamDateTime; }
            set { SetProperty(ref _dreamDateTime, value, nameof(DreamDateTime)); }
        }

        private int _lucidityId { get; set; }
        public LucidityLevel Lucidity
        {
            get { return (LucidityLevel)_lucidityId; }
            set { _lucidityId = (int)value; }
        }

        private int _positionId { get; set; }
        public SleepingPosition Position
        {
            get { return (SleepingPosition)_positionId; }
            set { _positionId = (int)value; }
        }
    }
}
