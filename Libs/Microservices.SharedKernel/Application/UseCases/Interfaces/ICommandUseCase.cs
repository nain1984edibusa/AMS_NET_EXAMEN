namespace Microservices.SharedKernel.Application.UseCases.Interfaces
{
    public interface ICommandUseCase<TCommand, TCommandResult> : IUseCase<TCommand, TCommandResult> 
        where TCommand : ICommand
        where TCommandResult : ICommandResult
    { }
    public interface ICommandUseCase<TCommand> : IUseCase<TCommand> 
        where TCommand : ICommand
    { }
}
