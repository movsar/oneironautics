using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Storage
    {
        private readonly Realm _realmInstance;
        private DreamRepository DreamsRepository { get; }
        private SignRepository SignRepository { get; }
        public Storage(bool cleanStart = false, string databasePath = "dreambase.realm")
        {
            RealmConfiguration DbConfiguration = new(databasePath);

            if (cleanStart)
            {
                Realm.DeleteRealm(DbConfiguration);
            }

            _realmInstance = Realm.GetInstance(DbConfiguration);

            DreamsRepository = new DreamRepository(_realmInstance);
            SignRepository = new SignRepository(_realmInstance);
        }

        public IEnumerable<TModel> GetAll<TModel>() where TModel : IModelBase
        {
            return SelectRepository<TModel>().GetAll<TModel>();
        }

        private IRepository SelectRepository<TModel>()
        {
            var t = typeof(TModel);
            switch (t)
            {
                case var _ when t.IsAssignableTo(typeof(IDream)):
                case var _ when t.IsAssignableFrom(typeof(IDream)):
                    return DreamsRepository;

                case var _ when t.IsAssignableTo(typeof(ISign)):
                case var _ when t.IsAssignableFrom(typeof(ISign)):
                    return SignRepository;

                default:
                    throw new Exception();
            }
        }

        public void AddItem(IModelBase item)
        {
            SelectRepository<IModelBase>().Add(item);
        }

        public void UpdateItem(IModelBase item)
        {
            SelectRepository<IModelBase>().Update(item);
        }

        public void DeleteItem(IModelBase item)
        {
            SelectRepository<IModelBase>().Delete(item);
        }

        public IModelBase GetItem(IModelBase item)
        {
            return SelectRepository<IModelBase>().GetById<IModelBase>(item.Id);
        }

        public void DropDatabase(string dbPath)
        {
            Realm.DeleteRealm(new RealmConfiguration(dbPath));
        }
    }
}
