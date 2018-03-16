using System;
using Isen.Dotnet.Library.Models.Base;

namespace Isen.Dotnet.Library.Models.Implementation
{
    public class Person : BaseModel
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public City city { get;set; }
        public int? cityId { get;set; }
        public DateTime? BirthDate { get;set; }
        public int? Age => BirthDate.HasValue ? 
            (int?)((DateTime.Now - BirthDate.Value).Days/365.25):
            null;

        private string _name;

        public override string Name
        {
            get { return _name ?? $"{FirstName} {LastName}";} 
            set { _name = value;}
            
        }
        public override string Display =>
            $"{base.Display} | Age={Age} | [City={city}] ";
        
    }

   
}