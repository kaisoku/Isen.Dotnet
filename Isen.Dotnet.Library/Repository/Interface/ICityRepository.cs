using Isen.Dotnet.Library.Models.Implementation;
using System.Collections.Generic;

namespace Isen.Dotnet.Library.Repository.Interface
{
    
  public interface ICityRepository
    {
        IList<City> GetAll();
        City Single(int id);
    }
}
