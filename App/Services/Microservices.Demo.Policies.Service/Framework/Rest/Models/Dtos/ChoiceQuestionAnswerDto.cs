using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos
{
    public class ChoiceQuestionAnswerDto : QuestionAnswerDto<string>
    {
        public override QuestionType QuestionType => QuestionType.Choice;
    }
}
