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

        public void DeleteItem<TModel>(IModelBase item) where TModel : IModelBase
        {
            SelectRepository<TModel>().Delete(item);
        }

        public void UpdateItem<TModel>(IModelBase item) where TModel : IModelBase
        {
            SelectRepository<TModel>().Update(item);
        }

        public void AddItem<TModel>(IModelBase item) where TModel : IModelBase
        {
            SelectRepository<TModel>().Add(item);
        }

        public IEnumerable<TModel> GetAll<TModel>() where TModel : IModelBase
        {
            return SelectRepository<TModel>().GetAll<TModel>();
        }

        public IEnumerable<IDream> FindDreamsByContent(string str)
        {
            return _storage.DreamsRepository.FindByContents(str);
        }

    }
}
