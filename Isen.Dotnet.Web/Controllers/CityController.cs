using Microsoft.AspNetCore.Mvc;
using Isen.Dotnet.Library.Repository.Interface;
using Isen.Dotnet.Library.Models.Implementation;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Web.Controllers
{
    public class CityController : BaseController<City>
    {
        public CityController(
            ILogger<CityController> logger,
            ICityRepository repository)
            : base(logger,repository){}
    }
}