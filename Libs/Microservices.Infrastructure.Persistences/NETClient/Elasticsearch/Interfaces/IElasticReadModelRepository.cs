using Microservices.SharedKernel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Interfaces
{
    public interface IElasticReadModelRepository<T>
        : IGenericRepository<T>
        where T : class
    {
        string GetIndexName();
    }
}
