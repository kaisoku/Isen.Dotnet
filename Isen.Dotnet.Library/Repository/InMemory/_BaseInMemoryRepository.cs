using System.Linq;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;
using Isen.Dotnet.Library.Repository.Base;

namespace Isen.Dotnet.Library.Repository.InMemory
{
  
    public abstract class BaseInMemoryRepository<T> : BaseRepository<T>
        where T : BaseModel
    {
        protected IList<T> _modelCollection;
        public override void Delete(int id){
            var list = ModelCollection.ToList();
            var modelToRemove = Single(id);
            list.Remove(modelToRemove);
            _modelCollection = list;
        }
       
    }
}