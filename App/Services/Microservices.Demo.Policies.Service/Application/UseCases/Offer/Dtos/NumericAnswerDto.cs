using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public class NumericAnswerDto : AnswerDto<decimal>
    {
        public NumericAnswerDto(){}
        public NumericAnswerDto(string questionCode, decimal answer)
        {
            QuestionCode = questionCode;
            AnswerValue = answer;
        }
        public override QuestionType QuestionType => QuestionType.Numeric;
    }
}
