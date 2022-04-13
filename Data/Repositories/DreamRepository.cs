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
    public class DreamRepository : Repository<IDream>
    {
        Realm _realmInstance;

        public DreamRepository(Realm realmInstance) : base(realmInstance)
        {
            _realmInstance = realmInstance;

            // At timestamp each time a dream is modified
            realmInstance.All<DreamEntity>().SubscribeForNotifications((sender, changes, error) =>
            {
                foreach (var dream in sender)
                {
                    dream.ModifiedAt = DateTime.Now;
                }
            });
        }
        public void GetAllLucidDreams()
        {
            throw new NotImplementedException();
        }

        public IDream Get(ObjectId dreamId)
        {
            return _realmInstance.All<DreamEntity>().FirstOrDefault(dream => dream.Id.Equals(dreamId));
        }

        public IEnumerable<Dream> FindByTitle(string title)
        {
            var result = _realmInstance.All<DreamEntity>().Where(dreamEntity => dreamEntity.Title.Contains(title));
            return ToPlainObjects<DreamEntity, Dream>(result);
        }
    }
}
