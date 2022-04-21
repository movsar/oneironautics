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
        public DreamRepository DreamsRepository { get; }
        public SignRepository SignRepository { get; }
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

        public void DropDatabase(string dbPath)
        {
            Realm.DeleteRealm(new RealmConfiguration(dbPath));
        }
    }
}
