using Microservices.Demo.Products.Service.Application.UseCases.Product.Enums;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos
{
    public abstract class QuestionDto
    {
        public string QuestionCode { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public abstract QuestionType QuestionType { get; }
    }
}
