using Microservices.Demo.Products.Service.Application.UseCases.Product.Enums;

namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos
{
    public class ChoiceQuestionDto : QuestionDto
    {
        public IList<ChoiceDto> Choices { get; set; }

        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
