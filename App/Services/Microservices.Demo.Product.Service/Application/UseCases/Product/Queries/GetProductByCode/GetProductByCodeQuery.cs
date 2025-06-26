using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode
{
    public class GetProductByCodeQuery:IQuery
    {        
        public string Code { get; set; }
    }
}
