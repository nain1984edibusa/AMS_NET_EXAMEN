using Microservices.Demo.RestClients.Pricing.Models.Converters;
using Microservices.Demo.RestClients.Pricing.Models.Enums;
using System.Text.Json.Serialization;

namespace Microservices.Demo.RestClients.Pricing.Models.Dtos
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