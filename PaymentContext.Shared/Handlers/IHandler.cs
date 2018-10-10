using PaymentContext.Shared.Commands;

namespace PaymentContext.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        // always when you call a command ou will receive a command as output (standard)
         ICommandResult Handle(T command);
    }
}
