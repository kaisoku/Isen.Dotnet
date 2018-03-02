using System.Linq;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;
using Isen.Dotnet.Library.Repository.Base;

namespace Isen.Dotnet.Library.Repository.InMemory
{
  
    public class InMemoryPersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private ICityRepository _cityResository;

        public InMemoryPersonRepository(ICityRepository cityRepository)
        {
            _cityResository = cityRepository;
        }
        private IList<Person> _modelCollection;
        public override IQueryable<Person> ModelCollection
        {
            get
            {
                if(_modelCollection == null)
                {
                    _modelCollection = new List<Person>
                    {
                        new Person{Id=1, FirstName="Michel", LastName = "Gohou",BirthDate=new System.DateTime(1965,05,08),city=_cityResository.Single(1)},
                        new Person{Id=2, FirstName="Michel", LastName = "Bohiri",BirthDate=new System.DateTime(1972,06,03),city=_cityResository.Single(2)},
                        new Person{Id=3, FirstName="Michel", LastName = "Ange",BirthDate=new System.DateTime(1980,06,03),city=_cityResository.Single(3)},
                        new Person{Id=4, FirstName="Michel", LastName = "Demon",BirthDate=new System.DateTime(1990,06,03),city=_cityResository.Single(4)}
                    };
                }
                return _modelCollection.AsQueryable();
            }
        }

        public override void Delete(int id){
            var list = ModelCollection.ToList();
            foreach(var m in list){
                if(m.Id == id)
                {
                    list.Remove(m);
                    _modelCollection = list;
                    break;
                }
            }
        }
    }
}