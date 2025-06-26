using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Convertes;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos;
using System.Text.Json.Serialization;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos
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