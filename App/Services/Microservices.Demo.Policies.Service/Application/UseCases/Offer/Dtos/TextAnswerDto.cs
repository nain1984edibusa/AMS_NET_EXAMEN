using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public class TextAnswerDto : AnswerDto<string>
    {
        public TextAnswerDto(){}
        public TextAnswerDto(string questionCode, string answer)
        {
            QuestionCode = questionCode;
            AnswerValue = answer;
        }
        public override QuestionType QuestionType => QuestionType.Text;
    }
}
