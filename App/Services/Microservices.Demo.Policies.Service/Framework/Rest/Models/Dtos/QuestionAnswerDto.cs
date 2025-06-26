using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Converters;
using System.Text.Json.Serialization;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos
{
    [JsonConverter(typeof(QuestionAnswerDtoConverter))]
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
