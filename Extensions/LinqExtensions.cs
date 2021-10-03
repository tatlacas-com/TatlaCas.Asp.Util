using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TatlaCas.Asp.Core.Util.ViewModels;

namespace TatlaCas.Asp.Core.Util.Extensions
{
    public static class LinqExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(
            this IQueryable<T> source,
            List<DataTableSort> sort)
        {
            if (!(sort?.Count > 0))
            {
                return source.OrderBy("CreatedAt", "desc");
            }

            var result = source.OrderBy(sort[0].Field, sort[0].Sort);
            if (sort.Count <= 1) return result;
            for (var i = 1; i < sort.Count; i++)
            {
                result = result.ThenBy(sort[0].Field, sort[0].Sort);
            }

            return result;
        }

        public static IOrderedQueryable<T> OrderBy<T>(
            this IQueryable<T> source,
            string property, string order = "ASC")
        {
            var dir = "OrderBy";
            if ("desc".Equals(order?.ToLower()))
                dir = "OrderByDescending";
            return ApplyOrder<T>(source, property, dir);
        }

        public static IOrderedQueryable<T> ThenBy<T>(
            this IOrderedQueryable<T> source,
            string property, string order = "ASC")
        {
            var dir = "ThenBy";
            if ("desc".Equals(order?.ToLower()))
                dir = "ThenByDescending";
            return ApplyOrder<T>(source, property, dir);
        }

        static IOrderedQueryable<T> ApplyOrder<T>(
            IQueryable<T> source,
            string property,
            string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}