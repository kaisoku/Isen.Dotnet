using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;

namespace Isen.Dotnet.Library.Repository.Interface
{
    public interface IBaseRepository<T>
        where T : BaseModel
    {
        IList<T> GetAll();
        T Single(int id);
        T Single(string name);
    }
}
