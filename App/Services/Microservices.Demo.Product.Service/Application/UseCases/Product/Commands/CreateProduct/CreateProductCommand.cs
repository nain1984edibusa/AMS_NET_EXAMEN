using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct
{
    public class CreateProductCommand: ICommand
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public IList<CoverDto> Covers { get; set; }
        public IList<QuestionDto> Questions { get; set; }
        public int MaxNumberOfInsured { get; set; }

        public string Icon { get; set; }
    }
}
