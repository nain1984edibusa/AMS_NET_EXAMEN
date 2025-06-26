using AutoMapper;
using Azure.Core;
using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Framework.DI;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct
{
    public class DiscontinueProductUseCase : ICommandUseCase<DiscontinueProductCommand, DiscontinueProductResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public DiscontinueProductUseCase(IUnitOfWork unitOfWork, IMapper mapper,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<DiscontinueProductResult> ExecuteAsync(DiscontinueProductCommand input)
        {
            using var activity = _activitySource.StartActivity("DiscontinueProductUseCase.ExecuteAsync", ActivityKind.Internal);

            var product = await _unitOfWork.Products.FindById(input.ProductId);
            product.Discontinue();

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<DiscontinueProductResult>(product);

            activity.SetTagsFromObject(result, "Product");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }

}
