using Isen.Dotnet.Library.Models.Implementation;
using System.Linq;
using System.Collections.Generic;

namespace Isen.Dotnet.Library.Repository.IInMemory
{
  
    public class InMemoryCityRepository : ICityRepository
    {
        private IList<City> _cityCollection;
        private IList<City> CityCollection
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

        public IList<City> GetAll() => CityCollection;

        public City Single(int id) => CityCollection.SingleOrDefault (c => c.Id == id);
        public City Single(string name) => CityCollection.SingleOrDefault (c => c.Name == name);

    }
}