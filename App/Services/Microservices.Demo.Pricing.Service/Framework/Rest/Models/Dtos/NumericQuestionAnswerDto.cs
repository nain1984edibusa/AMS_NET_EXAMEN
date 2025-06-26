using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos
{
    public class NumericQuestionAnswerDto : QuestionAnswerDto<decimal>
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
    }

}
