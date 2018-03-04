using System;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;

namespace Isen.Dotnet.Library.Repository.Interface
{
    public interface IBaseRepository<T>
        where T : BaseModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T,bool> predicate);
        T Single(int id);
        T Single(string name);
        void Delete(int id);
        void Delete(T model);
        void DeleteRange(IEnumerable<T> models);
        void DeleteRange(params T[] models);
        //Update
        void Update(T model);
        void UpdateRange(IEnumerable<T> model);
        void UpdateRange(params T[] model);
    }
}
