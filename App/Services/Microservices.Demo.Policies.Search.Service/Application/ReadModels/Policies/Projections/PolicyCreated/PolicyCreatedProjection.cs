using AutoMapper;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.ReadModels.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated
{
    public class PolicyCreatedProjection : IEventProjection<PolicyCreatedEvent>
    {
        private readonly IReadModelUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public PolicyCreatedProjection(IReadModelUnitOfWork unitOfWork, IMapper mapper, ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }        
        public async Task ExecuteAsync(PolicyCreatedEvent input)
        {
            using var activity = _activitySource.StartActivity("PolicyCreatedProjection.ExecuteAsync", ActivityKind.Internal);

            var policyReadModel = _mapper.Map<PolicyReadModel>(input);
            await _unitOfWork.Policies.AddAsync(policyReadModel);
            await _unitOfWork.CompleteAsync();

            activity.SetTagsFromObject(policyReadModel, "PolicyReadModel");
            activity.SetStatus(ActivityStatusCode.Ok);
        }
    }
}
