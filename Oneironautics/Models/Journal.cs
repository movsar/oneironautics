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
        private IRepository SelectRepository<TModel>()
        {
            var t = typeof(TModel);
            switch (t)
            {
                case var _ when t.IsAssignableTo(typeof(IDream)):
                case var _ when t.IsAssignableFrom(typeof(IDream)):
                    return _storage.DreamsRepository;

                case var _ when t.IsAssignableTo(typeof(ISign)):
                case var _ when t.IsAssignableFrom(typeof(ISign)):
                    return _storage.SignRepository;

                default:
                    throw new Exception();
            }
        }

        public void DeleteItem(IModelBase item)
        {
            SelectRepository<IModelBase>().Delete(item);
        }

        public void UpdateItem(IModelBase item)
        {
            SelectRepository<IModelBase>().Update(item);
        }

        public void AddItem(IModelBase item)
        {
            SelectRepository<IModelBase>().Add(item);
        }

        public IEnumerable<TClass> GetAll<TClass>() where TClass : IModelBase
        {
            return SelectRepository<TClass>().GetAll<TClass>();
        }

        public IEnumerable<IDream> FindDreamsByContent(string str)
        {
            return _storage.DreamsRepository.FindByContents(str);
        }

    }
}
