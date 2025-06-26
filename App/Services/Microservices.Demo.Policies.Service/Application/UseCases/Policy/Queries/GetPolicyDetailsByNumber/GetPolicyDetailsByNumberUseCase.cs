using AutoMapper;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber
{
    public class GetPolicyDetailsByNumberUseCase : IQueryUseCase<GetPolicyDetailsByNumberQuery, GetPolicyDetailsByNumberResult>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public GetPolicyDetailsByNumberUseCase(IUnitOfWork unitOfWork, IMapper mapper,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }        

        public async Task<GetPolicyDetailsByNumberResult> ExecuteAsync(GetPolicyDetailsByNumberQuery input)
        {
            using var activity = _activitySource.StartActivity("GetPolicyDetailsByNumberUseCase.ExecuteAsync", ActivityKind.Internal);

            var policy = await _unitOfWork.Policies.WithNumber(input.PolicyNumber);
            if (policy == null) throw new ApplicationException($"Policy {input.PolicyNumber} not found!");
                        
            var result = _mapper.Map<GetPolicyDetailsByNumberResult>(policy);

            activity.SetTagsFromObject(result, "Policy");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }

}
