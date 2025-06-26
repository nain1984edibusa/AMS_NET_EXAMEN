using Elastic.Clients.Elasticsearch;
using Microservices.SharedKernel.Domain.Entities;
using Microservices.SharedKernel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories
{
    public class ElasticRepository<T, TElasticClient>
            : ElasticGenericRepository<T, TElasticClient>, IRepository<T>
            where T : class, IAggregateRoot
            where TElasticClient : ElasticsearchClient
    {
        public ElasticRepository(TElasticClient client) : base(client) { }
    }
}
