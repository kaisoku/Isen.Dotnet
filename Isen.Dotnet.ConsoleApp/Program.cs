using System;
using Isen.Dotnet.Library;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.InMemory;
using Isen.Dotnet.Library.Repository.Interface;

namespace Isen.Dotnet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string result =  Hello.GreetUpper("Kail");
            Console.WriteLine(result);
            var me = new Person
            {
                FirstName = "KASSAMBA",
                LastName = "Hussein Diaby",
                BirthDate = new DateTime(2000,6,6),
                city = new City{Name="Toulon"}
            };
            Console.WriteLine(me);
            var cityRepo = new InMemoryCityRepository();
            Console.WriteLine(cityRepo.Single(3));
            Console.WriteLine(cityRepo.Single("Toulon"));
            var allCities = cityRepo.GetAll();
            foreach(var c  in allCities) {Console.WriteLine(c);}*/

            ICityRepository cityRepository = new InMemoryCityRepository();
            IPersonRepository personRepository = new InMemoryPersonRepository(cityRepository);

            //Toutes les villes
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);

            //Toutes les personnes
            foreach(var p in personRepository.GetAll())
                Console.WriteLine(p);
            Console.WriteLine("----------------");
            //Toutes les personnes nees apres 1970
            var personBornAfter = 
                personRepository.Find(p=>
                p.BirthDate.Value.Year >= 1970);
            foreach(var p in personBornAfter)
                Console.WriteLine(p);
            Console.WriteLine("----------------");
            //toutes laes personnes avec age superieur a 40 ans
            var personOlderThan = personRepository.Find(
                p=> p.Age.HasValue && p.Age.Value >= 40);
            foreach(var p in personOlderThan)
                Console.WriteLine(p);
            Console.WriteLine("-------------");
            
            //Toutes les villes qui contiennent un e
            var citiesWithE = cityRepository.Find(c=>
            //c.Name.Contains("e")
            c.Name.IndexOf("e",StringComparison.CurrentCultureIgnoreCase)>=0);
            foreach(var c in citiesWithE)
                Console.WriteLine(c);
            Console.WriteLine("----------");

            //Effacer une ville
            var aubagne = cityRepository.Single("Aubagne");
            cityRepository.Delete(aubagne);
            foreach(var c in cityRepository.GetAll()){
                Console.WriteLine(c);
            }

        }
    }
}
