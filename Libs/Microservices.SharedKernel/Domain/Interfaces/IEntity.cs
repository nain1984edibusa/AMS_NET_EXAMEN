namespace Microservices.SharedKernel.Domain.Interfaces
{
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
