using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isen.Dotnet.Web.Models;
using Isen.Dotnet.Library.Repository.Interface;
using Isen.Dotnet.Library.Repository.InMemory;
using Isen.Dotnet.Library.Models.Implementation;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public class PersonController : BaseController<Person>
    {
        public PersonController(
            ILogger<PersonController> logger,
            IPersonRepository repository)
            : base(logger, repository){}
    }
}