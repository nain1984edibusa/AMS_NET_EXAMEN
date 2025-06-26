using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.CreatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.TerminatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Interfaces
{
    public interface IPolicyApplicationService
    {
        IQueryUseCase<GetAllPoliciesQuery, GetAllPoliciesResult> GetAllPolicies { get; }
        IQueryUseCase<GetPolicyDetailsByNumberQuery, GetPolicyDetailsByNumberResult> GetPolicyDetailsByNumber { get; }
        IQueryUseCase<GetHolderByPolicyIdQuery, GetHolderByPolicyIdResult> GetHolderByPolicyId { get; }
        ICommandUseCase<CreatePolicyCommand, CreatePolicyResult> CreatePolicy { get; }
        ICommandUseCase<TerminatePolicyCommand, TerminatePolicyResult> TerminatePolicy { get; }
    }
}