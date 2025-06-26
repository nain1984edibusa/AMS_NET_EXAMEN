using Microservices.SharedKernel.Application.Base;

namespace Microservices.SharedKernel.Application.ReadModels.Interfaces
{
    public interface IProjection<TPutProjection, TResult>
        where TPutProjection : IPutProjection
        where TResult : IResult
    {
        Task<TResult> ExecuteAsync(TPutProjection input);
    }
    public interface IProjection<TPutProjection>
        where TPutProjection : IPutProjection
    {
        Task ExecuteAsync(TPutProjection input);
    }
}
