using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using MongoDB.Bson;
using Realms;

namespace Data.Entities
{
    internal class DreamEntity : RealmObject, IDream
    {
        public DreamEntity()
        {
        }
        public DreamEntity(IDream dream)
        {
            Content = dream.Content;
            Title = dream.Title;
            Notes = dream.Notes;
            PositionId = (int)dream.Position;
            Position = dream.Position;
        }

        [PrimaryKey]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [Required]
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

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;
    }
}
