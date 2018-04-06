using Rebus.Handlers;

namespace CQRS.Core
{
    public interface IQueryHandler<in TQuery, out TEntity>
        where TQuery : IQuery
        where TEntity : class
    {
        TEntity Execute(TQuery query);
    }
}
