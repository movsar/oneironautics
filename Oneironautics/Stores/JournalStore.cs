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
        }

        internal void AddDream(IDream dream)
        {
            // Add to DB
            _journal.AddItem(dream);

            // Add to collection
            Dreams.Add(dream);
        }

        internal void LoadAllDreams()
        {
            // Load from DB
            IEnumerable<IDream> dreamsFromDb = _journal.GetAllDreams();

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
            IEnumerable<ISign> signsFromDb = _journal.GetAllSigns();

            // Refresh collection
            Signs.Clear();
            foreach (ISign sign in signsFromDb)
            {
                Signs.Add(sign);
            }
        }

        public void DeleteDreams(IEnumerable<IDream> dreamsToDelete)
        {
            // Remove from DB
            foreach (var dream in dreamsToDelete)
            {
                _journal.DeleteItem(dream);
            }

            // Remove from collection
            var ids = dreamsToDelete.Select(d => d.Id).ToList();
            var dreamsAsList = Dreams.ToList();

            foreach (var id in ids)
            {
                var index = dreamsAsList.FindIndex(d => d.Id == id);
                Dreams.RemoveAt(index);
            }
        }

        internal void AddSign(ISign sign)
        {
            // Add to DB
            _journal.AddItem(sign);

            // Add to collection
            Signs.Add(sign);
        }

        internal void UpdateSign(ISign sign)
        {
            // Update in runtime collection
            var index = Signs.ToList().FindIndex(d => d.Id == sign.Id);
            Signs[index] = sign;

            // Save to DB
            _journal.UpdateItem(sign);
        }

        internal void UpdateDream(IDream dream)
        {
            // Update in runtime collection
            var index = Dreams.ToList().FindIndex(d => d.Id == dream.Id);
            Dreams[index] = dream;

            // Save to DB
            _journal.UpdateItem(dream);

        }
    }
}
