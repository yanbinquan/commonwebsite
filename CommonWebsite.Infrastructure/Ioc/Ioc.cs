using System;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace CommonWebsite.Infrastructure.Ioc
{
    public class Ioc
    {
        private static readonly UnityContainer Container;

        static Ioc()
        {
            Container = new UnityContainer();
        }

        public static void Register<TInterface, TImpmentation>() where TImpmentation : TInterface
        {
            Container.RegisterType<TInterface, TImpmentation>();
        }

        public static void RegisterInheritedTypes(Assembly assembly, Type baseType)
        {
            Container.RegisterInheritedTypes(assembly, baseType);
        }

        public static T GetService<T>()
        {
            return Container.Resolve<T>();
        }
    }
}