using Microservices.SharedKernel.Application.Base;

namespace Microservices.SharedKernel.Application.UseCases.Interfaces
{
    public interface IUseCase<TPutUseCase, TResult>
        where TPutUseCase : IPutUseCase
        where TResult : IResult
    {
        Task<TResult> ExecuteAsync(TPutUseCase input);
    }    
    public interface IUseCase<TPutUseCase>
        where TPutUseCase : IPutUseCase
    {
        Task ExecuteAsync(TPutUseCase input);
    }
}
