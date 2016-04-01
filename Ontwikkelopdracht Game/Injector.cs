using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ontwikkelopdracht_Game
{
    public static class Injector
    {
        private static readonly IDictionary<Type, Type> Types = new Dictionary<Type, Type>();

        public static void Register<TContract, TImplementation>()
        {
            Types[typeof(TContract)] = typeof(TImplementation);
        }

        public static void Register(IDictionary<Type, Type> types)
        {
            foreach (KeyValuePair<Type, Type> keyValuePair in types)
            {
                Types[keyValuePair.Key] = keyValuePair.Value;
            }
        }

        public static T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private static object Resolve(Type contract)
        {
            Type implementation = Types[contract];
            ConstructorInfo constructor = implementation.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            if (constructorParameters.Length == 1)
            {
                return Activator.CreateInstance(implementation);
            }

            List<object> parameters = new List<object>(constructorParameters.Length);
            parameters.AddRange(constructorParameters.Select(parameterInfo => Resolve(parameterInfo.ParameterType)));

            return constructor.Invoke(parameters.ToArray());
        }
    }
}