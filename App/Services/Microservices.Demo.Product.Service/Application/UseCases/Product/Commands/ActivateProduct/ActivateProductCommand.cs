using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct
{
    public class ActivateProductCommand:ICommand
    {
        public Guid ProductId { get; set; }
    }
}
