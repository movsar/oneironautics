using Data.Interfaces;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Data.Entities
{
    public class SignToDream : IModelBase, IEntityBase, ISignToDream
    {
        [PrimaryKey]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string DreamId { get; set; }
        public string SignId { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;

        public void SetFromModel(IModelBase model)
        {
            var signToDream = model as ISignToDream;
            DreamId = signToDream.DreamId;
            SignId = signToDream.SignId;
        }
    }
}
