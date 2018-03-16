using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Data;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Base;
using Isen.Dotnet.Library.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Library.Repositories.DbContext
{
    public class DbContextPersonRepository :
        BaseDbContextRepository<Person>, IPersonRepository
    {
        public DbContextPersonRepository(
            ILogger<DbContextPersonRepository> logger, 
            ApplicationDbContext context) 
            : base(logger, context){}

            public override IQueryable<Person> Includes(
                IQueryable<Person> queryable) 
                => queryable.Include(p => p.city);
    }
}
