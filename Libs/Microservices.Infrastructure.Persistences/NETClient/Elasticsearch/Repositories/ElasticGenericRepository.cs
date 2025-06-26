using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Nodes;
using Microservices.SharedKernel.Domain.Entities;
using Microservices.SharedKernel.Domain.Interfaces;
using System.Security.Cryptography;

namespace Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories
{
    public class ElasticGenericRepository<T, TElasticClient>
             : ElasticReadOnlyRepository<T, TElasticClient>, IGenericRepository<T>
             where T : class
             where TElasticClient : ElasticsearchClient
    {                
        public ElasticGenericRepository(TElasticClient client)
            : base(client)
        {         
        }

        public virtual async Task AddAsync(T entity)
        {
            var idProp = entity.GetType().GetProperty("Id");
            var id = idProp?.GetValue(entity)?.ToString() ?? throw new InvalidOperationException("The entity does not have an Id property");
            //var response = await _client.Indices.CreateAsync(_indexName);
            var response = await _client.IndexAsync(entity, idx => idx.Index(_indexName).Id(id));
            if (!response.IsValidResponse)
            {
                throw new InvalidOperationException($"Failed to index entity: {response.ElasticsearchServerError?.Error?.Reason}");
            }
        }

        public virtual void Update(T entity)
        {
            var idProp = entity.GetType().GetProperty("Id");
            var id = idProp?.GetValue(entity)?.ToString() ?? throw new InvalidOperationException("The entity does not have an Id property");
            var response = _client.IndexAsync(entity, idx => idx.Index(_indexName).Id(id)).GetAwaiter().GetResult();
            if (!response.IsValidResponse)
            {
                throw new InvalidOperationException($"Failed to index entity: {response.ElasticsearchServerError?.Error?.Reason}");
            }
        }

        public virtual void Remove(T entity)
        {
            var idProp = entity.GetType().GetProperty("Id");
            var id = idProp?.GetValue(entity)?.ToString() ?? throw new InvalidOperationException("The entity does not have an Id property");
            var response = _client.DeleteAsync<T>(id, d => d.Index(_indexName)).GetAwaiter().GetResult();
            if (!response.IsValidResponse)
            {
                throw new InvalidOperationException($"Failed to delete entity: {response.ElasticsearchServerError?.Error?.Reason}");
            }
        }

        public void Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
