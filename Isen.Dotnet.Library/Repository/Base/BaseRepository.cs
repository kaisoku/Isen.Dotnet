using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;

namespace Isen.Dotnet.Library.Repository.Base
{
    public abstract class BaseRepository<T>: IBaseRepository<T>
        where T : BaseModel
    {
        public virtual IList<T> ModelCollection { get; }
        public virtual IList<T> GetAll() => ModelCollection;
        public virtual T Single(int id) => 
            ModelCollection.SingleOrDefault(c => c.Id == id);
        public virtual T Single(string name) => 
            ModelCollection.FirstOrDefault(c => c.Name == name);

    }

}