using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct
{
    public class DiscontinueProductCommand:ICommand
    {
        public Guid ProductId { get; set; }
    }
}
