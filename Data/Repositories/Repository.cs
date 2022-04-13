using Data.Entities;
using Data.Models;
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
    public class Repository<TEntity>
    {
        private Realm _realm;

        internal Repository(Realm realm) { 
            _realm = realm;
        }

        public void Add(TEntity entity)
        {
            var dream = new DreamEntity(entity as IDream);

            _realm.Write(() =>
            {
                _realm.Add(dream);
            });
        }

        public void Delete(TEntity entity)
        {
            _realm.Remove(entity as RealmObject);
        }

        public void Update(IDream dream)
        {
            var dreamEntity = _realm.Find<DreamEntity>(dream.Id);
            _realm.Write(() =>
            {
                dreamEntity.Content = dream.Content;
                dreamEntity.Title = dream.Title;
                dreamEntity.Notes = dream.Notes;
                dreamEntity.Position = dream.Position;
            });
            
        }

        public IEnumerable<TTarget> ToPlainObjects<TSource, TTarget> (IEnumerable<TSource> realmObjects)
        {
            string jsonString = JsonSerializer.Serialize(realmObjects);
            return JsonSerializer.Deserialize<IEnumerable<TTarget>>(jsonString);
        }
    }
}
