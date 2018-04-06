namespace CQRS.Core
{
    public interface ICommandDispatcher<TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
