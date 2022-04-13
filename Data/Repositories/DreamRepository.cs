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

        public IEnumerable<Dream> FindByTitle(string title)
        {
            var result = _realmInstance.All<DreamEntity>().Where(dreamEntity => dreamEntity.Title.Contains(title));
            return EntitiesToModels<DreamEntity, Dream>(result);
        }
    }
}
