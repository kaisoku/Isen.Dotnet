using System;
using Isen.Dotnet.Library;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.InMemory;

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
            Console.WriteLine(me);*/
            var cityRepo = new InMemoryCityRepository();
            Console.WriteLine(cityRepo.Single(3));
            Console.WriteLine(cityRepo.Single("Toulon"));
            var allCities = cityRepo.GetAll();
            foreach(var c  in allCities) {Console.WriteLine(c);}
        }
    }
}
