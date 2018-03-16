using System.Linq;
using Isen.Dotnet.Library.Data;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Repository.Base;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Library.Repositories.DbContext
{
    public abstract class BaseDbContextRepository<T> :
        BaseRepository<T>
            where T : BaseModel
    {
        // Référence au contexte EntityFramework (injecté)
        protected readonly ApplicationDbContext Context;

        // Implémentation concrète de la liste de T
        public override IQueryable<T> ModelCollection 
            => Context.Set<T>().AsQueryable();

        public BaseDbContextRepository(
            ILogger<BaseDbContextRepository<T>> logger,
            ApplicationDbContext context) 
            : base(logger)
        {
            Context = context;
        }

        public override void Delete(int id)
        {
            var model = Single(id);
            if (model != null) Context.Remove(model);
        }

        public override void Update(T model)
        {
            if (model.IsNew) Context.Add(model);
            else Context.Update(model);
        }

        public override void Save()
        {
            Context.SaveChanges();
        }
    }
}
