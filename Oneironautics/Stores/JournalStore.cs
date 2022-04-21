using Data;
using Data.Interfaces;
using DesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Stores
{
    public class JournalStore
    {
        private readonly Journal _journal;
        public ObservableCollection<IDream> Dreams = new();
        public ObservableCollection<ISign> Signs = new();

        public JournalStore(Journal journal)
        {
            _journal = journal;
            LoadAllDreams();
            LoadAllSigns();
        }

        private ICollection<TModel> SelectCollection<TModel>() where TModel : IModelBase
        {
            var t = typeof(TModel);
            switch (t)
            {
                case var _ when t.IsAssignableTo(typeof(IDream)):
                case var _ when t.IsAssignableFrom(typeof(IDream)):
                    return (ICollection<TModel>)Dreams;

                case var _ when t.IsAssignableTo(typeof(ISign)):
                case var _ when t.IsAssignableFrom(typeof(ISign)):
                    return (ICollection<TModel>)Signs;

                default:
                    throw new Exception();
            }
        }

        internal void AddItem<TModel>(IModelBase item) where TModel : IModelBase
        {
            // Add to DB
            _journal.AddItem<TModel>(item);

            // Add to collection
            SelectCollection<TModel>().Add((TModel)item);
        }

        internal void LoadAllDreams()
        {
            // Load from DB
            IEnumerable<IDream> dreamsFromDb = _journal.GetAll<Dream>();

            // Refresh collection
            Dreams.Clear();
            foreach (IDream dream in dreamsFromDb)
            {
                Dreams.Add(dream);
            }
        }

        internal void LoadAllSigns()
        {
            // Load from DB
            IEnumerable<ISign> signsFromDb = _journal.GetAll<Sign>();

            // Refresh collection
            Signs.Clear();
            foreach (ISign sign in signsFromDb)
            {
                Signs.Add(sign);
            }
        }

        public void DeleteItems<TModel>(IEnumerable<TModel> itemsToDelete) where TModel : IModelBase
        {
            // Remove from DB
            foreach (var item in itemsToDelete)
            {
                _journal.DeleteItem<TModel>(item);
            }

            // Remove from collection
            var ids = itemsToDelete.Select(d => d.Id).ToList();
            var dreamsAsList = SelectCollection<TModel>().ToList();

            foreach (var id in ids)
            {
                var index = dreamsAsList.FindIndex(d => d.Id == id);
                ((ObservableCollection<TModel>)SelectCollection<TModel>()).RemoveAt(index);
            }
        }

        internal void UpdateItem<TModel>(IModelBase item) where TModel : IModelBase
        {
            // Update in runtime collection
            var index = SelectCollection<TModel>().ToList().FindIndex(d => d.Id == item.Id);
            ((ObservableCollection<TModel>)SelectCollection<TModel>())[index] = (TModel)item;

            // Save to DB
            _journal.UpdateItem<TModel>(item);
        }
    }
}
