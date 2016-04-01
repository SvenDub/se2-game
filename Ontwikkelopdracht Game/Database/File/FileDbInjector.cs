using System;
using System.Collections.Generic;
using Ontwikkelopdracht_Game.Entity;

namespace Ontwikkelopdracht_Game.Database.File
{
    public static class FileDbInjector
    {
        public static IDictionary<Type, Type> Types
        {
            get
            {
                IDictionary<Type, Type> types = new Dictionary<Type, Type>();

                // Repositories
                types.Add(typeof(IRepository<List<GameObject>, string>), typeof(MapRepository));

                return types;
            }
        }
    }
}
