using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos
{
    public class NumericQuestionAnswerDto : QuestionAnswerDto<decimal>
    {
        public override QuestionType QuestionType => QuestionType.Numeric;
    }
}
