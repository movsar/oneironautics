using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using MongoDB.Bson;
using Realms;
using Data.Enums;

namespace Data.Entities
{
    public class DreamEntity : RealmObject, IDream, IEntityBase
    {
        [PrimaryKey]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public int Index { get; set; }

        [Required]
        public string Content { get; set; }

        public string Notes { get; set; }

        public DateTimeOffset DreamDateTime { get; set; } = DateTime.Now;

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
        [Ignored]
        public IList<string> AssociatedSignIds { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;

        // A utility metohd to assist when converting from RealmObject to a plain object and vice versa
        public void SetFromModel(IModelBase model)
        {
            var dream = model as IDream;

            Index = dream.Index;
            Position = dream.Position;
            Lucidity = dream.Lucidity;
            Content = dream.Content;
            Notes = dream.Notes;
            ModifiedAt = DateTime.Now;
        }
    }
}
