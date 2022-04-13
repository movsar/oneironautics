using Data.Repositories;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class Storage
    {
        private static Realm _realmInstance;

        public static DreamRepository DreamsRepository { get; set; }

        public static void Initialize(bool cleanStart = false, string databasePath = "dreambase.realm")
        {
            RealmConfiguration DbConfiguration = new(databasePath);

            if (cleanStart)
            {
                Realm.DeleteRealm(DbConfiguration);
            }

            _realmInstance = Realm.GetInstance(DbConfiguration);

            DreamsRepository = new DreamRepository(_realmInstance);
        }

        public static void DropDatabase(string dbPath)
        {
            Realm.DeleteRealm(new RealmConfiguration(dbPath));
        }
    }
}
