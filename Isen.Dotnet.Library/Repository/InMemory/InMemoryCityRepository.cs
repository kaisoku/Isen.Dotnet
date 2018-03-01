using System.Linq;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;
using Isen.Dotnet.Library.Repository.Base;

namespace Isen.Dotnet.Library.Repository.InMemory
{
  
    public class InMemoryCityRepository : BaseRepository<City>, ICityRepository
    {
        private IList<City> _cityCollection;
        public override IList<City> ModelCollection
        {
            get
            {
                if(_cityCollection == null)
                {
                    _cityCollection = new List<City>
                    {
                        new City{Id = 1, Name = "Toulon"},
                        new City{Id = 2, Name = "Toulouse"},
                        new City{Id = 3, Name = "Aubagne"},
                        new City{Id = 4, Name = "Marseille"}
                    };
                }
                return _cityCollection;
            }
        }
    }
}