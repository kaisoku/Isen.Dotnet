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

namespace Isen.Dotnet.Web.Controllers
{
    public abstract partial class BaseController<T> : Controller
        where T : BaseModel
    {
        protected IBaseRepository<T> _repository;
        protected readonly ILogger<BaseController<T>> _logger;

        public BaseController(
            ILogger<BaseController<T>> logger,
            IBaseRepository<T> repository)
        {
            _repository = repository;
            _logger = logger;
        }

        public virtual IActionResult Index()
        {            
            var model = _repository.GetAll();
            return View(model);
        }

        public virtual IActionResult Detail(int? id)
        {
            // Pas d'id > form vide (création)
            if (id == null) return View();
            // Récupérer la ville et la passer à la vue
            var model = _repository.Single(id.Value);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Detail(T model)
        {
            _repository.Update(model);
            _repository.Save();
            return RedirectToAction("Index");
        }

        public virtual IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _repository.Delete(id.Value);
                _repository.Save();
            }
            return RedirectToAction("Index");
        }
    }
}
