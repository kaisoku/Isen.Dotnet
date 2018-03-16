using System;
using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;
using Microsoft.Extensions.Logging;

namespace Isen.Dotnet.Library.Repository.Base
{
    public abstract class BaseRepository<T>: IBaseRepository<T>
        where T : BaseModel
    {
        protected readonly ILogger<BaseRepository<T>> Logger;


        //Liste des objets du modeleseRepository<T>> logger;
        public BaseRepository(
        ILogger<BaseRepository<T>> logger) => Logger = logger;
        //Liste des objets du modele
        public virtual IQueryable<T> ModelCollection { get; }
        public virtual IEnumerable<T> GetAll() => ModelCollection;

        //methode de listes(tout et query)
        public virtual IEnumerable<T> Find(
            Func<T,bool> predicate)
            {
                var queryable = ModelCollection;
                queryable = queryable.Where(m=> predicate(m));
                return queryable;
            }
        //methode pour renvoyer  l'element
        public virtual T Single(int id) => 
            ModelCollection.SingleOrDefault(c => c.Id == id);
        public virtual T Single(string name) => 
            ModelCollection.FirstOrDefault(c => c.Name == name);

        //Methode de Delete
        public abstract void Delete(int id);

        public virtual void Delete(T model) =>
            Delete(model.Id);

        public virtual void DeleteRange(IEnumerable<T> models){
            foreach(var m in models) Delete(m);
        }

        
        public virtual void DeleteRange(params T[] models) =>
            DeleteRange(models.AsEnumerable());
        //Update
        public abstract void Update(T model);

        public virtual void  UpdateRange(IEnumerable<T> model){
            foreach(var m in model) Update(m);
        }
        public virtual void UpdateRange(params T[] model) => UpdateRange(model.AsEnumerable());
        //Save
        public virtual void Save(){}
    }

}