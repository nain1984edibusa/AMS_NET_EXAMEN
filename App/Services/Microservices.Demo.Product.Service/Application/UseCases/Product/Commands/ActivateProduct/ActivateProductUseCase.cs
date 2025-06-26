using AutoMapper;
using Azure.Core;
using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Framework.DI;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct
{
    public class ActivateProductUseCase : ICommandUseCase<ActivateProductCommand, ActivateProductResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public ActivateProductUseCase(IUnitOfWork unitOfWork, IMapper mapper, ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<ActivateProductResult> ExecuteAsync(ActivateProductCommand input)
        {
            using var activity = _activitySource.StartActivity("ActivateProductUseCase.ExecuteAsync", ActivityKind.Internal);

            var product = await _unitOfWork.Products.FindById(input.ProductId);
            product.Activate();

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<ActivateProductResult>(product);

            activity.SetTagsFromObject(result, "Product");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }

}
