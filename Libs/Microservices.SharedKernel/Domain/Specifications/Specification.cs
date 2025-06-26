using System.Linq.Expressions;
using System;

namespace Microservices.SharedKernel.Domain.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract Expression<Func<T, bool>> Criteria { get; }

        public Specification<T> And(Specification<T> other)
            => new AndSpecification<T>(this, other);

        public Specification<T> Or(Specification<T> other)
            => new OrSpecification<T>(this, other);
    }
}
