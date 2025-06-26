
using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Interfaces;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent
{
    public class CreateOfferByAgentUseCase : ICommandUseCase<CreateOfferByAgentCommand, CreateOfferByAgentResult>
    {
        private readonly IPricingAgent _pricingAgent;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public CreateOfferByAgentUseCase(IUnitOfWork unitOfWork, IMapper mapper, IPricingAgent pricingAgent,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _pricingAgent = pricingAgent;
            _activitySource = activitySource;
        }        

        public async Task<CreateOfferByAgentResult> ExecuteAsync(CreateOfferByAgentCommand input)
        {            
            using var activity = _activitySource.StartActivity("CreateOfferByAgentUseCase.ExecuteAsync", ActivityKind.Internal);

            var priceParams = _mapper.Map<CalculatePriceParamsDto>(input);
            var price = await _pricingAgent.CalculatePrice(priceParams);


            var o = Domain.Policies.Entities.Offer.ForPriceAndAgent(
                priceParams.ProductCode,
                priceParams.PolicyFrom,
                priceParams.PolicyTo,
                null,
                price,
                input.AgentLogin
            );
                        
            await _unitOfWork.Offers.AddAsync(o);
            await _unitOfWork.CompleteAsync();
            var result = _mapper.Map<CreateOfferByAgentResult>(o);

            activity.SetTagsFromObject(result, "Offer");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }
}
