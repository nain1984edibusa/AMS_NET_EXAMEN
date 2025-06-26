using Microservices.Demo.Products.Service.Application.UseCases.Product.Enums;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos
{
    public class NumericQuestionDto: QuestionDto
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
    }
}
