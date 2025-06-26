using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos
{
    public class NumericQuestionAnswerDto : QuestionAnswerModel<decimal>
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
    }
}
