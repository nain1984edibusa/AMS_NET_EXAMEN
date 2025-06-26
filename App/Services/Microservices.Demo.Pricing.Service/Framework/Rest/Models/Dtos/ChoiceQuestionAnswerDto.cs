using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos
{
    public class ChoiceQuestionAnswerDto : QuestionAnswerDto<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
