using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopApp.Models
{
    public class Journal
    {
        private Storage _storage;
        public Journal(Storage storage)
        {
            _storage = storage;
        }

        public void UpdateDream(IDream dream)
        {
            _storage.DreamsRepository.Update(dream);
        }

        public void AddDream(IDream dream)
        {
            _storage.DreamsRepository.Add(dream);
        }

        public IEnumerable<IDream> GetAllDreams()
        {
            return _storage.DreamsRepository.GetAll<Dream>();
        }
    }
}
