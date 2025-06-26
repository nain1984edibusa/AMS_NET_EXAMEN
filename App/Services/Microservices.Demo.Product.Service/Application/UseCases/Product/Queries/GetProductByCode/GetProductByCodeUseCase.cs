using AutoMapper;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Framework.DI;
using Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Repositories;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode
{
    public class GetProductByCodeUseCase : IQueryUseCase<GetProductByCodeQuery, GetProductByCodeResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public GetProductByCodeUseCase(IUnitOfWork uow, IMapper mapper,ActivitySource activitySource)
        {
            _unitOfWork = uow;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<GetProductByCodeResult> ExecuteAsync(GetProductByCodeQuery input)
        {
            using var activity = _activitySource.StartActivity("GetProductByCodeUseCase.ExecuteAsync", ActivityKind.Internal);

            var product = await _unitOfWork.Products.FindOne(input.Code);
            var result = _mapper.Map<GetProductByCodeResult>(product);

            activity.SetTagsFromObject(result, "Product");
            activity.SetStatus(ActivityStatusCode.Ok);

            return result;
        }
    }
}
