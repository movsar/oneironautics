using Data.Entities;
using Data.Models;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class DreamRepository : Repository<DreamEntity>
    {
        static Realm _realmInstance;

        public DreamRepository(Realm realmInstance) : base(realmInstance)
        {
            _realmInstance = realmInstance;
        }

        public override void Add<TModel>(TModel model)
        {
            var dream = model as Dream;

            var lastDream = _realmInstance.All<DreamEntity>().LastOrDefault();
            dream.Index = lastDream == null ? 1 : lastDream.Index + 1;
          
            base.Add(dream);
        }

        public IEnumerable<Dream> FindByTitle(string title)
        {
            var result = _realmInstance.All<DreamEntity>().Where(dreamEntity => dreamEntity.Title.Contains(title));
            return EntitiesToModels<DreamEntity, Dream>(result);
        }
    }
}
