using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct
{
    public class DiscontinueProductResult : ProductDto, ICommandResult{}
}
