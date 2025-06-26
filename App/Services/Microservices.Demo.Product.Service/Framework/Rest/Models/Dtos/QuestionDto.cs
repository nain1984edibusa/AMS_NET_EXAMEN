using Microservices.Demo.Products.Service.Application.UseCases.Product.Enums;
using Microservices.Demo.Products.Service.Framework.Rest.Models.Converters;
using System.Text.Json.Serialization;

namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos
{
    [JsonConverter(typeof(QuestionDtoConverter))]
    public abstract class QuestionDto
    {
        public string QuestionCode { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        public abstract QuestionType QuestionType { get; }
    }
}
