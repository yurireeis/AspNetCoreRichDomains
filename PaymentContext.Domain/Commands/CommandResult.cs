using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public CommandResult(){}

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
