using Microservices.Demo.RestClients.Pricing.Models.Dtos;
using Microservices.Demo.RestClients.Pricing.Models.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Microservices.Demo.RestClients.Pricing.Models.Converters
{
    public class QuestionAnswerDtoConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(QuestionAnswerDto).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);

            var questionCode = jObject["questionCode"]?.Value<string>();
            var questionTypeToken = jObject["questionType"];
            QuestionType questionType;

            // Soporta tanto string como number para enums
            if (questionTypeToken.Type == JTokenType.String)
                questionType = Enum.Parse<QuestionType>(questionTypeToken.Value<string>(), ignoreCase: true);
            else if (questionTypeToken.Type == JTokenType.Integer)
                questionType = (QuestionType)questionTypeToken.Value<int>();
            else
                throw new JsonException("Invalid token type for QuestionType");

            var answerToken = jObject["answer"];

            switch (questionType)
            {
                case QuestionType.Text:
                    return new TextQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = answerToken.Value<string>()
                    };
                case QuestionType.Numeric:
                    return new NumericQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = answerToken.Value<decimal>()
                    };
                case QuestionType.Choice:
                    return new ChoiceQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = answerToken.Value<string>()
                    };
                default:
                    throw new JsonException($"Unexpected question type {questionType}");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();

            var questionAnswer = (QuestionAnswerDto)value;

            writer.WritePropertyName("questionCode");
            writer.WriteValue(questionAnswer.QuestionCode);

            writer.WritePropertyName("questionType");
            writer.WriteValue(questionAnswer.QuestionType.ToString());

            writer.WritePropertyName("answer");
            switch (questionAnswer)
            {
                case TextQuestionAnswerDto text:
                    writer.WriteValue(text.Answer);
                    break;
                case NumericQuestionAnswerDto number:
                    writer.WriteValue(number.Answer);
                    break;
                case ChoiceQuestionAnswerDto choice:
                    writer.WriteValue(choice.Answer);
                    break;
                default:
                    throw new JsonException($"Unknown type {value.GetType().Name}");
            }

            writer.WriteEndObject();
        }
    }
}
