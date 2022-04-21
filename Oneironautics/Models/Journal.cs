using Data;
using Data.Interfaces;
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

        public void DeleteItem(IModelBase item)
        {
            _storage.DreamsRepository.Delete(item);
        }

        public void UpdateItem(IModelBase item)
        {
            _storage.DreamsRepository.Update(item);
        }

        public void AddItem(IModelBase item)
        {
            _storage.DreamsRepository.Add(item);
        }

        public IEnumerable<IDream> GetAllDreams()
        {
            return _storage.DreamsRepository.GetAll<Dream>();
        }
        public IEnumerable<ISign> GetAllSigns()
        {
            return _storage.SignRepository.GetAll<Sign>();
        }
    }
}
