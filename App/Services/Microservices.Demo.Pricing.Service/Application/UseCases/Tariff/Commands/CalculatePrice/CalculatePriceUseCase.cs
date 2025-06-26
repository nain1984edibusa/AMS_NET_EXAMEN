using AutoMapper;
using FluentValidation;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Validators;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice
{
    public class CalculatePriceUseCase : ICommandUseCase<CalculatePriceCommand, CalculatePriceResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CalculatePriceCommandValidator _commandValidator;
        private readonly ActivitySource _activitySource;

        public CalculatePriceUseCase(
            IUnitOfWork unitOfWork, 
            IMapper mapper,
            ActivitySource activitySource
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _commandValidator = new CalculatePriceCommandValidator();
            _activitySource = activitySource;
        }

        public async Task<CalculatePriceResult> ExecuteAsync(CalculatePriceCommand input)
        {
            using var activity = _activitySource.StartActivity("CalculatePriceUseCase.ExecuteAsync", ActivityKind.Internal);

            await _commandValidator.ValidateAndThrowAsync(input);
            var tariff = await _unitOfWork.Tariffs[input.ProductCode];
            var calculation = _mapper.Map<Calculation>(input);
            var calculated = tariff.CalculatePrice(calculation);
            var result = _mapper.Map<CalculatePriceResult>(calculated);

            activity.SetTagsFromObject(result, "Tariff");            
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }
}
