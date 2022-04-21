using Data.Interfaces;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IRepository
    {
        void Add<TModel>(TModel model) where TModel : IModelBase;
        void Delete<TModel>(TModel model) where TModel : IModelBase;
        TTarget EntitiesToModels<TSource, TTarget>(TSource realmObject);
        IEnumerable<TModel> GetAll<TModel>() where TModel : IModelBase;
        TModel GetById<TModel>(string id);
        void Update<TModel>(TModel model) where TModel : IModelBase;
    }
}