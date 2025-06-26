using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Domain.Interfaces
{
    public interface IGenericRepository<T> : IReadOnlyRepository<T>
    {
        Task AddAsync(T entity);
        void Upsert(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
