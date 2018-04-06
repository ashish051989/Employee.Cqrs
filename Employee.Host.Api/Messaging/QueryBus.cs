using CQRS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Host.Api.Messaging
{
    public class QueryBus
    {
        private readonly QueryHandler factory;

        public QueryBus()
        {
            factory = new QueryHandler();
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery
            where TResult : class
        {
            var handler = factory.GetHandler<TQuery, TResult>();
            return handler.Execute(query);
        }
    }
}