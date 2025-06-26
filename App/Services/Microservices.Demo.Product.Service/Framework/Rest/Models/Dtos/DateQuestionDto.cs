using Microservices.Demo.Products.Service.Application.UseCases.Product.Enums;

namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos
{
    public class DateQuestionDto : QuestionDto
    {
        public override QuestionType QuestionType => QuestionType.Date;
    }
}
