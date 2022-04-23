using Data;
using Data.Interfaces;
using Data.Models;
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
        public List<IDream> Dreams = new();
        public List<ISign> Signs = new();

        public JournalStore(Journal journal)
        {
            _journal = journal;
            LoadAllDreams();
            LoadAllSigns();
        }

        public event Action<IModelBase> ItemAdded;
        public event Action<IModelBase> ItemUpdated;
        public event Action<IModelBase> ItemDeleted;

        private IList<TModel> SelectCollection<TModel>() where TModel : IModelBase
        {
            var t = typeof(TModel);
            switch (t)
            {
                case var _ when t.IsAssignableTo(typeof(IDream)):
                case var _ when t.IsAssignableFrom(typeof(IDream)):
                    return (IList<TModel>)Dreams;

                case var _ when t.IsAssignableTo(typeof(ISign)):
                case var _ when t.IsAssignableFrom(typeof(ISign)):
                    return (IList<TModel>)Signs;

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

            // Let everybody know
            ItemAdded?.Invoke(item);
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

        public void DeleteItem<TModel>(TModel item) where TModel : IModelBase
        {
            // Remove from DB
            _journal.DeleteItem<TModel>(item);

            // Remove from collection
            var index = SelectCollection<TModel>().ToList().FindIndex(d => d.Id == item.Id);
            SelectCollection<TModel>().RemoveAt(index);

            // Let everybody know
            ItemDeleted?.Invoke(item);
        }

        public void DeleteItems<TModel>(IEnumerable<TModel> itemsToDelete) where TModel : IModelBase
        {
            foreach (var item in itemsToDelete)
            {
               DeleteItem(item);
            }
        }

        internal void UpdateItem<TModel>(IModelBase item) where TModel : IModelBase
        {
            // Update in runtime collection
            var index = SelectCollection<TModel>().ToList().FindIndex(d => d.Id == item.Id);
            ((ObservableCollection<TModel>)SelectCollection<TModel>())[index] = (TModel)item;

            // Save to DB
            _journal.UpdateItem<TModel>(item);

            // Let everybody know
            ItemUpdated?.Invoke(item);
        }
    }
}
