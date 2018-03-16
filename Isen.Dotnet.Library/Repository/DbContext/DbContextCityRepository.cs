using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Data;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Base;
using Isen.Dotnet.Library.Repository.Interface;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Library.Repositories.DbContext
{
    public class DbContextCityRepository :
        BaseDbContextRepository<City>, ICityRepository
    {
        public DbContextCityRepository(
            ILogger<DbContextCityRepository> logger, 
            ApplicationDbContext context) 
            : base(logger, context)
        {
        }
    }
}
