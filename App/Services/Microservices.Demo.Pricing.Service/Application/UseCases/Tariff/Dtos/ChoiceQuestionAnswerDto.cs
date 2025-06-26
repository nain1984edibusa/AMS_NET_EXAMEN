using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos
{
    public class ChoiceQuestionAnswerDto : QuestionAnswerModel<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
