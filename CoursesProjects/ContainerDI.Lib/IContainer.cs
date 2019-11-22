using System;
using System.Collections.Concurrent;

namespace ContainerDI.Lib
{
    interface IContainer
    {
        void Register(Type type);
        void Register<T>();
        void Bind(Type firstType, Type secondType);
        void Bind<FromType, ToType>();
        object Get(Type type);
        T Get<T>();
    }
}
