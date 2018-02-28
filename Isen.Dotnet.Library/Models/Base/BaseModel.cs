using System;

namespace Isen.Dotnet.Library.Base
{
    public abstract class BaseModel
    {
        public int Id{ get;set; }
        public virtual string Name{ get;set; }

        public virtual string Display =>
        $"[Id={Id}] | {Name}";

        public override string ToString() =>Display;
    }
        
}