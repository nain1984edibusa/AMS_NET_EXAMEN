using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder
{

    public class GetHolderByPolicyIdResult : PolicyVersionDto, IQueryResult { }
}
