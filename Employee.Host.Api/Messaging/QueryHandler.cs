using CQRS.Core;
using Employee.Configuration;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Host.Api.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    public class QueryHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TQuery"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public IQueryHandler<TQuery, TResult> GetHandler<TQuery, TResult>() where TQuery : IQuery 
            where TResult : class
        {
            var handlers = GetHandlerTypes<TQuery>().ToList();

            var queryHandler = handlers.Select(handler =>
                (IQueryHandler<TQuery, TResult>)IOC.Container.Resolve(handler)).FirstOrDefault();

            return queryHandler;
        }

        private IEnumerable<Type> GetHandlerTypes<T>() where T : IQuery
        {
            var handlers = typeof(IQueryHandler<,>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();


            return handlers;
        }
    }
}