using System;
using System.Linq;
using System.Reflection;
using CommonWebsite.Infrastructure.Extensions;
using Microsoft.Practices.Unity;

namespace CommonWebsite.Infrastructure.Ioc
{
    public static class UnityContainerExtensions
    {
        public static void RegisterInheritedTypes(this IUnityContainer container, Assembly assembly, Type baseType)
        {
            var allTypes = assembly.GetTypes();
            var baseInterfaces = baseType.GetInterfaces();
            foreach (var type in allTypes)
            {
                if (type.BaseType == null || !type.BaseType.GenericEq(baseType)) continue;
                var typeInterface = type.GetInterfaces().FirstOrDefault(x => !baseInterfaces.Any(bi => bi.GenericEq(x)));
                if (typeInterface == null)
                    continue;
                container.RegisterType(typeInterface, type);
            }
        }
    }
}