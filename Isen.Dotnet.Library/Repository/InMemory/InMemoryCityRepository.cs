using System.Linq;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;
using Isen.Dotnet.Library.Repository.Base;

namespace Isen.Dotnet.Library.Repository.InMemory
{
  
    public class InMemoryCityRepository : BaseRepository<City>, ICityRepository
    {
        private IList<City> _modelCollection;
        public override IQueryable<City> ModelCollection
        {
            get
            {
                if(_modelCollection == null)
                {
                    _modelCollection = new List<City>
                    {
                        new City{Id = 1, Name = "Toulon"},
                        new City{Id = 2, Name = "Toulouse"},
                        new City{Id = 3, Name = "Aubagne"},
                        new City{Id = 4, Name = "Marseille"}
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }
    }
}