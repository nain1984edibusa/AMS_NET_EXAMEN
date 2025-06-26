using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos
{
    public abstract class QuestionAnswerDto
    {
        public string QuestionCode { get; set; }
        public abstract QuestionType QuestionType { get; }
        public abstract object GetAnswer();
    }
    public abstract class QuestionAnswerModel<T> : QuestionAnswerDto
    {
        public T Answer { get; set; }

        public override object GetAnswer()
        {
            return Answer;
        }
    }
}
