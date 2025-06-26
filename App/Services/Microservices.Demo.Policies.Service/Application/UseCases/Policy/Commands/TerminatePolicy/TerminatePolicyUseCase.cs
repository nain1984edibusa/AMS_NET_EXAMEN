using AutoMapper;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Infrastructure.Kafka.Producer;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.TerminatePolicy
{
    public class TerminatePolicyUseCase : ICommandUseCase<TerminatePolicyCommand, TerminatePolicyResult>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageProducer _messagePublisher;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public TerminatePolicyUseCase(IUnitOfWork unitOfWork, IMapper mapper, IMessageProducer messagePublisher,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _messagePublisher = messagePublisher;
            _mapper = mapper;
            _activitySource = activitySource;
        }        

        public async Task<TerminatePolicyResult> ExecuteAsync(TerminatePolicyCommand input)
        {
            using var activity = _activitySource.StartActivity("TerminatePolicyUseCase.ExecuteAsync", ActivityKind.Internal);

            var policy = await _unitOfWork.Policies.WithNumber(input.PolicyNumber);
            var terminationResult = policy.Terminate(input.TerminationDate);

            await _messagePublisher.PublishMessage(_mapper.Map<PolicyTerminatedEvent>(terminationResult));
            await _unitOfWork.CompleteAsync();

            var result = new TerminatePolicyResult
            {
                PolicyNumber = policy.Number,
                MoneyToReturn = terminationResult.AmountToReturn
            };

            activity.SetTagsFromObject(result, "Policy");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;       
        }
    }

}
