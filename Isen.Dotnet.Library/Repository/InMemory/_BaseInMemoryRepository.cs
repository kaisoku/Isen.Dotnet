using System.Linq;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Repository.Base;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Library.Repository.InMemory
{

    public abstract class BaseInMemoryRepository<T> : BaseRepository<T>
        where T : BaseModel
    {
        protected IList<T> _modelCollection;

        public BaseInMemoryRepository(
            ILogger<BaseInMemoryRepository<T>> logger) : base(logger)
        {
        }

        public int NewId()=>
            GetAll().Max(m => m.Id) + 1;
        public override void Delete(int id){
            var list = ModelCollection.ToList();
            var modelToRemove = Single(id);
            list.Remove(modelToRemove);
            _modelCollection = list;
        }

        public override void Update(T model){
            if(model == null) return;
            var list = ModelCollection.ToList();
            if(model.IsNew){
                model.Id = NewId();
                list.Add(model);
            }else{
                var existing = list.FirstOrDefault(
                    m => m.Id == model.Id);
                existing = model;
            }
            _modelCollection = list;
        }
       
    }
}