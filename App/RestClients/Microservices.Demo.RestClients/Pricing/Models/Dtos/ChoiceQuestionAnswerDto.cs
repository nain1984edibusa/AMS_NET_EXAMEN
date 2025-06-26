using Microservices.Demo.RestClients.Pricing.Models.Enums;

namespace Microservices.Demo.RestClients.Pricing.Models.Dtos
{
    public class ChoiceQuestionAnswerDto : QuestionAnswerDto<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
