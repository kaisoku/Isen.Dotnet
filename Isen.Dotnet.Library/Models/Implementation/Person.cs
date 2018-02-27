using System;

namespace Isen.Dotnet.Library.Models.Implementation
{
    public class Person
    {
        public int Id{ get;set; }
        public string Name{ get;set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public City city { get;set; }
        public DateTime? BirthDate { get;set; }
        public int? Age => BirthDate != null ? (int?)((DateTime.Now - BirthDate.Value).Days/365):null;

        public string Display =>
            $"[Id={Id}] | {FirstName} {LastName} | Age={Age} | [City={city}] ";
        
        public override string ToString() => Display;
    }

   
}