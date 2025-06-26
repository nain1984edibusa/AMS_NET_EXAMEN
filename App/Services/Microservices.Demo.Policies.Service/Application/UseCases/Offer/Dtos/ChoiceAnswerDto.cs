using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public class ChoiceAnswerDto : AnswerDto<string>
    {
        public ChoiceAnswerDto(){} 
        public ChoiceAnswerDto(string questionCode, string answer)
        {
            QuestionCode = questionCode;
            AnswerValue = answer;
        }
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
