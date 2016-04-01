using System;
using System.Collections.Generic;

namespace Ontwikkelopdracht_Game.Database
{
    public interface IRepository<T, ID> : IDisposable
    {
        IEnumerable<ID> List(); 
        void Delete(ID id);
        bool Exists(ID id);
        T FindOne(ID id);
        S Save<S>(S entity, ID id) where S : T;
    }
}