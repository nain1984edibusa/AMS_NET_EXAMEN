using System.Linq.Expressions;
using System;

namespace Microservices.SharedKernel.Domain.Specifications
{
    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> Criteria
        {
            get
            {
                var left = _left.Criteria;
                var right = _right.Criteria;
                var parameter = Expression.Parameter(typeof(T));
                var body = Expression.OrElse(
                    Expression.Invoke(left, parameter),
                    Expression.Invoke(right, parameter));
                return Expression.Lambda<Func<T, bool>>(body, parameter);
            }
        }
    }
}
