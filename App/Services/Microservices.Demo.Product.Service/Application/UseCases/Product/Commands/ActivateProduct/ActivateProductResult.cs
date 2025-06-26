using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct
{
    public class ActivateProductResult : ProductDto, ICommandResult { }
}
