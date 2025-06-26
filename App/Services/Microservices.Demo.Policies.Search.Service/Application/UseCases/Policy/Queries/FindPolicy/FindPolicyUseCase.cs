using AutoMapper;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy
{
    public class FindPolicyUseCase : IQueryUseCase<FindPolicyQuery, FindPolicyResult>
    {
        private readonly IReadOnlyUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public FindPolicyUseCase(IReadOnlyUnitOfWork unitOfWork, IMapper mapper,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<FindPolicyResult> ExecuteAsync(FindPolicyQuery input)
        {
            using var activity = _activitySource.StartActivity("FindPolicyUseCase.ExecuteAsync", ActivityKind.Internal);

            var policy = await _unitOfWork.Policies.FindAsync(input.QueryText);                        
            var result = _mapper.Map<FindPolicyResult>(policy);

            activity.SetTagsFromObject(result.Policies.Count(),"PoliciesCount");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }

}
