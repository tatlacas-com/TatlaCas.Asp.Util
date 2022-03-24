using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TatlaCas.Asp.Core.Util.Extensions;

public static class TypeExtensions
{
    /// <summary>
    /// Get types whose Namespace equals the namespaceBase
    /// </summary>
    /// <param name="types">The types to check</param>
    /// <param name="namespaceBase">the namespace to match with</param>
    /// <returns>All types who have the namespace equals namespaceBase</returns>
    public static IEnumerable<Type> WhenNsEquals(this IEnumerable<Type> types, string namespaceBase)
    {
        return types.Where(x => x.Namespace != null && x.Namespace.Equals(namespaceBase));
    }

    public static IEnumerable<Type> CreatableTypes(this Assembly assembly)
    {
        return assembly
            .ExceptionSafeGetTypes()
            .Select(t => t.GetTypeInfo())
            .Where(t => !t.IsAbstract)
            .Where(t => t.DeclaredConstructors.Any(c => !c.IsStatic && c.IsPublic))
            .Select(t => t.AsType());
    }

    public static IEnumerable<Type> CreatableTypesInNs(this Assembly assembly, string ns,
        bool includeSubDir = false,
        List<string> exclude = null)
    {
        return assembly
            .ExceptionSafeGetTypes()
            .Select(t => t.GetTypeInfo())
            .Where(t => !t.IsAbstract)
            .Where(t =>
            {
                var allowedConstructor =
                    t.DeclaredConstructors.Any(c => !c.IsStatic && c.IsPublic);
                var currNs = t.AsType().Namespace;
                var fullName = t.AsType().FullName;
                var allowedNamespace = includeSubDir
                    ? currNs?.StartsWith(ns) == true
                    : currNs?.Equals(ns)== true;

                var isInExcludes = exclude?.Any(p => fullName?.StartsWith(p)==true) == true;
                return allowedConstructor && allowedNamespace && !isInExcludes;
            })
            .Select(t => t.AsType());
    }

    public static IEnumerable<Type> ExceptionSafeGetTypes(this Assembly assembly)
    {
        try
        {
            return assembly.GetTypes();
        }
        catch (ReflectionTypeLoadException e)
        {
            Console.WriteLine("ReflectionTypeLoadException masked during loading of {0} - error {1}",
                assembly.FullName, e.ToLongString());

            if (e.LoaderExceptions != null)
            {
                foreach (var excp in e.LoaderExceptions)
                {
                    Console.WriteLine(excp.Message);
                }
            }

            if (Debugger.IsAttached)
                Debugger.Break();

            return new Type[0];
        }
    }

    public class ServiceTypeAndImplementationTypePair
    {
        public ServiceTypeAndImplementationTypePair(List<Type> serviceTypes, Type implementationType)
        {
            ImplementationType = implementationType;
            ServiceTypes = serviceTypes;
        }

        public List<Type> ServiceTypes { get; private set; }
        public Type ImplementationType { get; private set; }
    }

    public static IEnumerable<ServiceTypeAndImplementationTypePair> AsInterfaces(this IEnumerable<Type> types) =>
        types.Select(t => new ServiceTypeAndImplementationTypePair(t.GetInterfaces().ToList(), t));

    public static void AddScoped(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs,
        IServiceCollection services)
    {
        foreach (var pair in pairs)
        {
            foreach (var serviceType in pair.ServiceTypes)
            {
                services.AddScoped(serviceType, pair.ImplementationType);
            }
        }
    }
}