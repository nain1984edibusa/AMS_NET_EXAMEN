namespace Microservices.SharedKernel.Application.UseCases.Interfaces
{
    public interface IQueryUseCase<TQuery, TQueryResult> : IUseCase<TQuery, TQueryResult> 
        where TQuery : IQuery
        where TQueryResult : IQueryResult
    { }
    public interface IQueryUseCase<TQuery> : IUseCase<TQuery> 
        where TQuery : IQuery
    { }
}
