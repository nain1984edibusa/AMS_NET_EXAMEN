using Elastic.Clients.Elasticsearch;
using Microservices.SharedKernel.Domain.Entities;
using Microservices.SharedKernel.Domain.Interfaces;
using Microservices.SharedKernel.Domain.Specifications;
using System.Linq.Expressions;

namespace Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories
{
    public class ElasticReadOnlyRepository<T, TElasticClient>
        : IReadOnlyRepository<T>
        where T : class
        where TElasticClient : ElasticsearchClient
    {
        protected readonly TElasticClient _client;
        protected readonly string _indexName;

        public string GetIndexName() { return _indexName; }
        public ElasticReadOnlyRepository(TElasticClient client)
        {
            _client = client;
            _indexName = typeof(T).Name.ToLower();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            var response = await _client.GetAsync<T>(id.ToString(), idx => idx.Index(_indexName));
            return response.Found ? response.Source : null;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var response = await _client.SearchAsync<T>(s => s
                .Indices(_indexName)
                .Query(q => q.MatchAll())
                .Size(1000));
            return response.Documents;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            // Elasticsearch does not support .NET expressions directly. You could serialize the predicate to JSON and use it as a filter with a library like [QueryTranslator](https://github.com/yojimbo87/Elasticsearch.QueryTranslator)
            // Here, as an example, we serialize the predicate and throw not supported:
            throw new NotSupportedException("FindAsync with Expression is not supported directly in Elasticsearch. Use FindAsync with Specification or implement mapping.");
        }

        public virtual async Task<IEnumerable<T>> FindAsync(ISpecification<T> specification)
        {
            var query = specification.ToElasticQuery();
            var response = await _client.SearchAsync<T>(s => s
                .Indices(_indexName)
                .Query(query)
                .Size(1000));
            return response.Documents;
        }

        public virtual async Task<bool> AnyAsync()
        {
            var response = await _client.CountAsync<T>(c => c
                 .Indices(_indexName)
                 .Query(q => q.MatchAll())
             );
            return response.Count > 0;
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            // Not directly supported, same as FindAsync with Expression
            throw new NotSupportedException("AnyAsync with Expression is not supported directly in Elasticsearch.");
        }

    }
}
