using ProductManagement.Domain.Commands.Contracts;


namespace ProductManagement.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : Commands.Contracts.ICommand
    {
        ICommandResult Handler(T command);
    }
}
