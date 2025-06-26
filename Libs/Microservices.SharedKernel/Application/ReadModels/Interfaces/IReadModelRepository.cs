using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Domain.Interfaces
{
    public interface IReadModelRepository<T>
        : IGenericRepository<T> 
        where T : class
    {
   
    }
}