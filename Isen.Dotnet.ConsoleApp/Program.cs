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

            //Etat initial
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);
            Console.WriteLine("-------------------");
            //Ajouter une ville
            var cannes =  new City { Name = "Cannes"};
            cityRepository.Update(cannes);
            foreach(var c in cityRepository.GetAll())
                Console.WriteLine(c);
            Console.WriteLine("-----------------");
            //Mettre a jour une ville
            var aubagne = cityRepository.Single("Aubagne");
            if(aubagne != null){
                aubagne.Name += " sur-mer";
                cityRepository.Update(aubagne);
                foreach(var c in cityRepository.GetAll())
                    Console.WriteLine(c);
                Console.WriteLine("----------------");
            }

            //Ajout et mise a jour dans une meme update
            var lyon  =  new City{ Name = "Lyon"};
            if(aubagne!=null) aubagne.Name = "Aubagne";
            cityRepository.UpdateRange(lyon,aubagne);
            foreach(var c in  cityRepository.GetAll()) 
                Console.WriteLine(c);
            Console.WriteLine("--------------------------");

            //ajout et mis a jour d'une personne
            var jonDoe = new Person{
                FirstName = "Jon",
                LastName = "DOE",
                BirthDate = new DateTime(1975,8,1),
                city = cityRepository.Single("Lyon")
            };

            var person2 = personRepository.Single(2);
            person2.BirthDate = person2.BirthDate.Value.AddYears(-100);
            personRepository.UpdateRange(jonDoe,person2);
            foreach(var p in personRepository.GetAll())
                Console.WriteLine(p);
            Console.WriteLine("-----------------------");



        }
    }
}
