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
    internal class JournalStore
    {
        public Journal Journal { get; }
        public List<IDream> Dreams { get; }

        public JournalStore(Journal journal)
        {
            Journal = journal;
            Dreams = new List<IDream>();
        }

        public void AddDream(IDream dream)
        {
            Journal.AddDream(dream);
        }

        internal IEnumerable<IDream>? GetAllDreams()
        {
            IEnumerable<IDream> dreamsFromDb = Journal.GetAllDreams();

            Dreams.Clear();
            Dreams.AddRange(dreamsFromDb);

            return Dreams;
        }
    }
}
