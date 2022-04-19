using Data;
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

        public ObservableCollection<IDream> Dreams = new();

        public JournalStore(Journal journal)
        {
            _journal = journal;

            Initialize();
        }

        private void Initialize()
        {
            LoadAllDreams();
        }

        internal void AddDream(IDream dream)
        {
            // Add to DB
            _journal.AddDream(dream);

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

        public void DeleteDream(IDream dream)
        {
            // Delete from runtime collection
            var index = Dreams.ToList().FindIndex(d => d.Id == dream.Id);
            Dreams[index] = dream;

            // Remove from DB
            _journal.DeleteDream(dream);
        }

        internal void UpdateDream(IDream dream)
        {
            // Update in runtime collection
            var index = Dreams.ToList().FindIndex(d => d.Id == dream.Id);
            Dreams[index] = dream;

            // Save to DB
            _journal.UpdateDream(dream);

        }
    }
}
