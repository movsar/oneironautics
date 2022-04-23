using Data.Entities;
using Data.Interfaces;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SignRepository : Repository<SignEntity>
    {
        private readonly Realm _realmInstance;
        public SignRepository(Realm realmInstance) : base(realmInstance)
        {
            _realmInstance = realmInstance;
        }

        public string[] GetSignIdsByDreamAssociations(string dreamId)
        {
            // Get ids of the signs associated with the dream
            var currentlyAssociatedSignIds = _realmInstance
                    .All<SignToDreamEntity>()
                    .Where(signToDream => signToDream.DreamId == dreamId).ToList()
                    .Select(signToDream => signToDream.SignId);

            return currentlyAssociatedSignIds.ToArray();
        }

      
    }
}
