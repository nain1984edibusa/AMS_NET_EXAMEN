using Microservices.Demo.RestClients.Pricing.Models.Enums;

namespace Microservices.Demo.RestClients.Pricing.Models.Dtos
{
    public class NumericQuestionAnswerDto : QuestionAnswerDto<decimal>
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
    }

}
