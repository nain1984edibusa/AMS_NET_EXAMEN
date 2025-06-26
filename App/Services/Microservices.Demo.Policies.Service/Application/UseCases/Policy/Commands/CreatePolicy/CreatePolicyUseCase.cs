using AutoMapper;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;
using Microservices.Infrastructure.Kafka.Producer;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.CreatePolicy
{
    public class CreatePolicyUseCase : ICommandUseCase<CreatePolicyCommand, CreatePolicyResult>
    {        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageProducer _messagePublisher;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public CreatePolicyUseCase(IUnitOfWork unitOfWork, IMapper mapper, IMessageProducer messagePublisher,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _messagePublisher = messagePublisher;
            _mapper = mapper;
            _activitySource = activitySource;
        }        

        public async Task<CreatePolicyResult> ExecuteAsync(CreatePolicyCommand input)
        {
            using var activity = _activitySource.StartActivity("CreatePolicyUseCase.ExecuteAsync", ActivityKind.Internal);

            var offer = await _unitOfWork.Offers.WithNumber(input.OfferNumber);
            var customer = new PolicyHolder
            (
                input.PolicyHolder.FirstName,
                input.PolicyHolder.LastName,
                input.PolicyHolder.TaxId,
                Address.Of
                (
                    input.PolicyHolderAddress.Country,
                    input.PolicyHolderAddress.ZipCode,
                    input.PolicyHolderAddress.City,
                    input.PolicyHolderAddress.Street
                )
            );
            var policy = offer.Buy(customer);

            await _unitOfWork.Policies.AddAsync(policy);
            await _messagePublisher.PublishMessage(_mapper.Map<PolicyCreatedEvent>(policy));
            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<CreatePolicyResult>(policy);

            activity.SetTagsFromObject(result, "Policy");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }

}
