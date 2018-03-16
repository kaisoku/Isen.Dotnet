using System;
using System.Collections.Generic;
using Isen.Dotnet.Library.Models.Base;

namespace Isen.Dotnet.Library.Models.Implementation
{
    public class City : BaseModel{
        public List<Person> PersonCollection { get; set; }
        public int? PersonCount => PersonCollection?.Count;
    }
   
}