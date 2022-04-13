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
        public static DreamRepository DreamsRepository { get; set; }

        public static void Initialize(bool cleanStart = false)
        {
            RealmConfiguration DbConfiguration = new("dreambase.realm");

            if (cleanStart)
            {
                Realm.DeleteRealm(DbConfiguration);
            }

            var realm = Realm.GetInstance(DbConfiguration);

            DreamsRepository = new DreamRepository(realm);
        }
    }
}
