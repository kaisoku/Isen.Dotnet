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
using Isen.Dotnet.Library.Models.Base;
using System.Dynamic;

namespace Isen.Dotnet.Web.Controllers
{
    public abstract partial class BaseController<T> : Controller
        where T : BaseModel
    {
        [HttpGet]
        [Route("api/[controller]")]
        public JsonResult GetAll()
        {
            var all = _repository
                .GetAll()
                .Select(t => t.ToDynamic())
                .ToList();
            return Json(all);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public JsonResult GetById(int id)
        {
            var single = _repository.Single(id);
            return Json(single);
        }
    }

}