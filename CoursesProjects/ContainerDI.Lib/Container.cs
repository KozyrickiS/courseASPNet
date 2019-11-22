using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerDI.Lib
{
    public class Container : IContainer
    {
        public ConcurrentDictionary<Type, Type> _registeredTypes;
        public Container()
        {
            _registeredTypes = new ConcurrentDictionary<Type, Type>();
        }
        public void Register(Type type)
        {
            _registeredTypes.TryAdd(type, type);
        }

        public void Register<T>()
        {
            _registeredTypes.TryAdd(typeof(T), typeof(T));
        }

        public void Bind(Type firstType, Type secondType)
        {
            if (firstType.IsAssignableFrom(secondType))
            {
                _registeredTypes.TryAdd(firstType, secondType);
            }
        }

        public void Bind<FromType, ToType>()
        {
            if (typeof(FromType).IsAssignableFrom(typeof(ToType)))
            {
                _registeredTypes.TryAdd(typeof(FromType), typeof(ToType));
            }
        }

        public object Get(Type type)
        {
            Type resolvedType = _registeredTypes[type];
            var constructor = resolvedType.GetConstructors();
            var constructorParameters = constructor.First().GetParameters();
            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(resolvedType);
            }
            object[] parameters = new object[constructorParameters.Length];
            for (int i = 0; i < constructorParameters.Count(); i++)
            {
                parameters[i] = constructorParameters[i].ParameterType; ;
            }
            return Activator.CreateInstance(_registeredTypes[type], parameters);
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }
    }
}
