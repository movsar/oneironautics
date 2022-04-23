using Data.Entities;
using Data.Interfaces;
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
        private readonly Realm _realmInstance;

        public DreamRepository(Realm realmInstance) : base(realmInstance)
        {
            _realmInstance = realmInstance;
        }
        private void UpdateSignAssociations(IDream dream)
        {
            List<string> newSignIdAssociations = dream.AssociatedSignIds.ToList();

            _realmInstance.Write(() =>
            {
                var existingAssociations = _realmInstance
                    .All<SignToDreamEntity>()
                    .Where(signToDream => signToDream.DreamId == dream.Id);

                foreach (var association in existingAssociations)
                {
                    if (newSignIdAssociations.Contains(association.SignId))
                    {
                        // Already exists, should not be associated again
                        newSignIdAssociations.Remove(association.SignId);
                    }
                    else
                    {
                        // Sign currently is not selected, association should be removed
                        _realmInstance.Remove(association);
                    }
                }

                // Add new ones
                foreach (var signId in newSignIdAssociations)
                {
                    _realmInstance.Add(new SignToDreamEntity() { SignId = signId, DreamId = dream.Id });
                }
            });
        }

        private void DeleteSignAssociations(string dreamId)
        {
            _realmInstance.Write(() =>
            {
                var existingAssociations = _realmInstance
                    .All<SignToDreamEntity>()
                    .Where(signToDream => signToDream.DreamId == dreamId);

                _realmInstance.RemoveRange(existingAssociations);
            });
        }
        private void SetIndex(IDream dream)
        {
            var lastDream = _realmInstance.All<DreamEntity>().LastOrDefault();
            dream.Index = lastDream == null ? 1 : lastDream.Index + 1;
        }
        public override void Add<TModel>(TModel model)
        {
            var dream = model as IDream;
            SetIndex(dream);

            base.Add(dream);
            UpdateSignAssociations(dream);
        }

        public IEnumerable<IDream> FindByContents(string str)
        {
            var result = _realmInstance.All<DreamEntity>().Where(dreamEntity => dreamEntity.Content.Contains(str));
            return EntitiesToModels<DreamEntity, IDream>(result);
        }

        public override void Update<TModel>(TModel model)
        {
            base.Update(model);
            UpdateSignAssociations(model as IDream);
        }

        public override void Delete<TModel>(TModel model)
        {
            base.Delete(model);
            DeleteSignAssociations(model.Id);
        }

        private void SetSignAssociations(IEnumerable<IDream> dreams)
        {
            foreach (var dream in dreams)
            {
                var dreamSignIds = _realmInstance.All<SignToDreamEntity>()
                    .Where(std => std.DreamId == dream.Id).ToList();

                dream.AssociatedSignIds = dreamSignIds.Select(std => std.SignId).ToList();
            }
        }
        public override IEnumerable<TModel> GetAll<TModel>()
        {
            var allDreams = base.GetAll<TModel>() as IEnumerable<IDream>;
            SetSignAssociations(allDreams);
            return allDreams as IEnumerable<TModel>;
        }
    }
}
