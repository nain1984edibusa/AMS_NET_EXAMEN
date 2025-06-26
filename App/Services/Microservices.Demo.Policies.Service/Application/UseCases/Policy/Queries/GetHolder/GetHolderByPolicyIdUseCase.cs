using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder
{
    public class GetHolderByPolicyIdUseCase : IQueryUseCase<GetHolderByPolicyIdQuery, GetHolderByPolicyIdResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public GetHolderByPolicyIdUseCase(IUnitOfWork unitOfWork, IMapper mapper, ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<GetHolderByPolicyIdResult> ExecuteAsync(GetHolderByPolicyIdQuery input)
        {
            using var activity = _activitySource.StartActivity("GetHolderByPolicyIdResultUseCase.ExecuteAsync", ActivityKind.Internal);

            var policy = await _unitOfWork.Policies.WithPolicyId(input.PolicyId);
            var result = _mapper.Map<GetHolderByPolicyIdResult>(policy);

            activity.SetTagsFromObject(result, "Policy");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }
}
