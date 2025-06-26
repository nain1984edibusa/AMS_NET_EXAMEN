using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.CreatePolicy
{
    public class CreatePolicyResult: PolicyDto, ICommandResult
    {        
    }
}
