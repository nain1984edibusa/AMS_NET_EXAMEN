using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public abstract class AnswerDto
    {
        public string QuestionCode { get; protected set; }
        public abstract QuestionType QuestionType { get; }
        public abstract object GetAnswerValue();

        public static AnswerDto Create(QuestionType questionType, string questionCode, object answerValue)
        {
            switch (questionType)
            {
                case QuestionType.Text:
                    return new TextAnswerDto(questionCode, (string)answerValue);
                case QuestionType.Choice:
                    return new ChoiceAnswerDto(questionCode, (string)answerValue);
                case QuestionType.Numeric:
                    return new NumericAnswerDto(questionCode, (decimal)answerValue);
                default:
                    throw new ArgumentException();
            }
        }
    }

    public abstract class AnswerDto<T> : AnswerDto
    {
        public T AnswerValue { get; protected set; }

        public override object GetAnswerValue()
        {
            return AnswerValue;
        }
    }
}
