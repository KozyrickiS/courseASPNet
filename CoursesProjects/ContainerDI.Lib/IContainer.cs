using System;

namespace ContainerDI.Lib
{
    public interface IContainer
    {
        void Register(Type type);
        void Register<T>();
        void Bind(Type firstType, Type secondType);
        void Bind<FromType, ToType>();
        object Get(Type type);
        T Get<T>();
    }
}
