using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos
{
    public class TextQuestionAnswerDto : QuestionAnswerDto<string>
    {
        public override QuestionType QuestionType => QuestionType.Text;
    }
}
