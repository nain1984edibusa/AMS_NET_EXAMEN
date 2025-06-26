using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Domain.Interfaces
{
    public interface IRepository<T>
        : IGenericRepository<T> 
        where T : IAggregateRoot        
    {
   
    }
}