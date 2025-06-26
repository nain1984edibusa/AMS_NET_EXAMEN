using AutoMapper;
using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Repositories;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts
{
    public class GetAllProductsUseCase : IQueryUseCase<GetAllProductsQuery, GetAllProductsResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ActivitySource _activitySource;

        public GetAllProductsUseCase(IUnitOfWork uow, IMapper mapper,ActivitySource activitySource)
        {   
            _unitOfWork = uow;
            _mapper = mapper;
            _activitySource = activitySource;
        }

        public async Task<GetAllProductsResult> ExecuteAsync(GetAllProductsQuery input)
        {            
            using var activity = _activitySource.StartActivity("GetAllProductsUseCase.ExecuteAsync", ActivityKind.Internal);
                     
            var products = await _unitOfWork.Products.FindAllActive();
            var result = _mapper.Map<GetAllProductsResult>(products);
            
            Console.WriteLine($"[Telemetry] Found {result.Products.Count()} products.");

            activity.SetTag("Products.Count", result.Products.Count());
            activity.SetStatus(ActivityStatusCode.Ok);
                        
            Console.WriteLine($"[Telemetry] Activity '{activity.DisplayName}' completed with status: {activity.Status}");
            

            return result;
        }
    }
}
