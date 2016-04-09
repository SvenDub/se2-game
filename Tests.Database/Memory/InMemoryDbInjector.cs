using System;
using System.Collections.Generic;
using Ontwikkelopdracht_Game.Database;
using Ontwikkelopdracht_Game.Entity;

namespace Tests.Database.Memory
{
    public static class InMemoryDbInjector
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
