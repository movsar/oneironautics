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

        private readonly List<IDream> _dreams;
        public IEnumerable<IDream> Dreams => _dreams;
        
        public JournalStore(Journal journal)
        {
            _journal = journal;
            _dreams = new List<IDream>();

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
            _dreams.Add(dream);
        }

        internal void LoadAllDreams()
        {
            // Load from DB
            IEnumerable<IDream> dreamsFromDb = _journal.GetAllDreams();

            // Refresh collection
            _dreams.Clear();
            _dreams.AddRange(dreamsFromDb);
        }

        internal void UpdateDream(IDream dream)
        {
            // Save to DB
            _journal.UpdateDream(dream);

            var index = _dreams.FindIndex(d => d.Id == dream.Id);
            _dreams[index] = dream;
        }
    }
}
