using Data.Entities;
using Data.Interfaces;
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
        private readonly Realm _realmInstance;

        public DreamRepository(Realm realmInstance) : base(realmInstance)
        {
            _realmInstance = realmInstance;
        }

        public override void Add<TModel>(TModel model)
        {
            var dream = model as IDream;

            var lastDream = _realmInstance.All<DreamEntity>().LastOrDefault();
            dream.Index = lastDream == null ? 1 : lastDream.Index + 1;
          
            base.Add(dream);
        }

        public IEnumerable<IDream> FindByContents(string str)
        {
            var result = _realmInstance.All<DreamEntity>().Where(dreamEntity => dreamEntity.Content.Contains(str));
            return EntitiesToModels<DreamEntity, IDream>(result);
        }
    }
}
