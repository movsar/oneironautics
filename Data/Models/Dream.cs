using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using MongoDB.Bson;

namespace Data.Models
{
    public class Dream : IDream
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int Lucidity { get; set; }
        private int PositionId { get; set; }
        public SleepingPosition Position
        {
            get { return (SleepingPosition)PositionId; }
            set { PositionId = (int)value; }
        }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set;  }
    }

    public enum SleepingPosition
    {
        Unknown,
        Right,
        Back,
        Left,
        Stomach
    }
}
