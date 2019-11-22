using ContainerDI.Lib;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;

namespace ContainerDI.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void Test_Registered_Add_String()
        {
            var container = new Container();
            container.Register(typeof(String));
            ConcurrentDictionary<Type, Type> dict = container._registeredTypes;
            dict[typeof(String)].Should().Be(typeof(String));
        }

        [Test]
        public void Test_Invalid_Resolving()
        {
            var container = new Container();
            container.Bind(typeof(IContainer), typeof(Container));
            ConcurrentDictionary<Type, Type> dict = container._registeredTypes;
            var cnt = (IContainer)container.Get(typeof(IContainer));
            dict.Count.Should().Be(1);
        }

        [Test]
        public void Test_Register_With_Generic_Method()
        {
            var container = new Container();
            container.Register<Container>();
            ConcurrentDictionary<Type, Type> dict = container._registeredTypes;
            dict[typeof(Container)].Should().Be(typeof(Container));
        }

        [Test]
        public void Test_Bind_With_Generic_Method()
        {
            var container = new Container();
            container.Bind<IContainer, Container>();
            ConcurrentDictionary<Type, Type> dict = container._registeredTypes;
            var cnt = (IContainer)container.Get(typeof(IContainer));
            cnt.GetType().Should().Be(typeof(Container));
        }

        [Test]
        public void Test_Get_With_Generic_Method()
        {
            var container = new Container();
            container.Bind<IContainer, Container>();
            ConcurrentDictionary<Type, Type> dict = container._registeredTypes;
            var cnt = container.Get<IContainer>();
            cnt.GetType().Should().Be(typeof(Container));
        }
    }
}
