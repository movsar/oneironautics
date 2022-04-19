using Data.Enums;
using Data.Interfaces;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class SignEntity : RealmObject, ISign, IEntityBase
    {
        [PrimaryKey]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        [Required]
        public string Title { get; set; }

        private int TypeId { get; set; }
        public SignType Type
        {
            get { return (SignType)TypeId; }
            set { TypeId = (int)value; }
        }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;

        public void SetFromModel(IModelBase model)
        {
            var sign = model as ISign;

            Title = sign.Title;
            Type = sign.Type;
            ModifiedAt = DateTime.Now;
        }
    }
}
