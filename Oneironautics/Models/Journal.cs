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
            _storage.DeleteItem(item);
        }

        public void UpdateItem(IModelBase item)
        {
            _storage.UpdateItem(item);
        }


        public void AddItem(IModelBase item)
        {
            _storage.AddItem(item);
        }

        public IEnumerable<IDream> GetAllDreams()
        {
            return _storage.GetAll<Dream>();
        }
        public IEnumerable<ISign> GetAllSigns()
        {
            return _storage.GetAll<Sign>();
        }
    }
}
