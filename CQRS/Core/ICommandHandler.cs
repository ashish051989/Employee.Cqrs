using Memento;
using Rebus.Handlers;

namespace CQRS.Core
{
    public interface ICommandHandler<in TMessage> : IHandleMessages<TMessage> where TMessage : Command
    {
    }
}
