using System;
using System.Collections.Generic;
using System.Linq;
using Isen.Dotnet.Library.Models.Base;
using Isen.Dotnet.Library.Models.Implementation;
using Isen.Dotnet.Library.Repository.Interface;

namespace Isen.Dotnet.Library.Repository.Base
{
    public abstract class BaseRepository<T>: IBaseRepository<T>
        where T : BaseModel
    {
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
        public virtual void Delete(int id){
            foreach(var m in ModelCollection){
                if(m.Id == id)
                    ModelCollection.ToList().Remove(m);
            }
        }

        public virtual void Delete(T model) =>
            Delete(model.Id);

    }

}