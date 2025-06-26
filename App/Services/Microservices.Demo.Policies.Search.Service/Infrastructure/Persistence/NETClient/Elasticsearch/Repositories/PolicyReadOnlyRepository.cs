
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories;

namespace Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.Repositories
{
    public class PolicyReadOnlyRepository : ElasticReadOnlyRepository<PolicyReadModel, ElasticsearchClient>, IPolicyReadOnlyRepository
    {
        public PolicyReadOnlyRepository(ElasticsearchClient context) : base(context) { }

        public async Task<List<PolicyReadModel>> FindAsync(string queryText)
        {            
            var result = await _client
                           .SearchAsync<PolicyReadModel>(s => s
                                .Indices(_indexName)
                                .From(0)
                                .Size(10)
                                .Query(q => q
                                    .MultiMatch(mm => mm
                                        .Query(queryText)
                                        .Fields(
                                            f=> f.PolicyNumber,
                                            f=> f.PolicyHolder
                                        )
                                        .Type(TextQueryType.BestFields)
                                        .Fuzziness(new Fuzziness("AUTO"))
                                   )    
                                )
                           );
            
            return result.Documents.ToList();
        }
    }
}
