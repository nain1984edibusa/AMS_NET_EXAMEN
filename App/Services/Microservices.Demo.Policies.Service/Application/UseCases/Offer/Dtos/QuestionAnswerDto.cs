using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public abstract class QuestionAnswerDto
    {
        public string QuestionCode { get; set; }
        public abstract QuestionType QuestionType { get; }
        public abstract object GetAnswer();
    }

    public abstract class QuestionAnswerDto<T> : QuestionAnswerDto
    {
        public T Answer { get; set; }

        public override object GetAnswer()
        {
            return Answer;
        }
    }
}
