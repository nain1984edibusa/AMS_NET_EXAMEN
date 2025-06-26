using System.Text.Json.Serialization;
using System.Text.Json;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Enums;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Converters
{
    internal class QuestionAnswerDtoConverter : JsonConverter<QuestionAnswerDto>
    {
        public override QuestionAnswerDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            string questionCode = null;
            QuestionType? questionType = null;
            object answer = null;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException();

                string propertyName = reader.GetString();
                reader.Read();

                switch (propertyName)
                {
                    case "questionCode":
                        questionCode = reader.GetString();
                        break;
                    case "questionType":
                        questionType = Enum.Parse<QuestionType>(reader.GetString());
                        break;
                    case "answer":
                        // Aquí depende de questionType, pero aún no lo sabes.
                        // Puedes guardar el raw o leerlo luego por tipo
                        answer = JsonElement.ParseValue(ref reader);
                        break;
                }
            }

            if (questionCode == null || questionType == null)
                throw new JsonException();

            switch (questionType)
            {
                case QuestionType.Text:
                    return new TextQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = ((JsonElement)answer).GetString()
                    };
                case QuestionType.Numeric:
                    return new NumericQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = ((JsonElement)answer).GetDecimal()
                    };
                case QuestionType.Choice:
                    return new ChoiceQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = ((JsonElement)answer).GetString()
                    };
                default:
                    throw new JsonException($"Unknown QuestionType: {questionType}");
            }
        }

        public override void Write(Utf8JsonWriter writer, QuestionAnswerDto value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("questionCode", value.QuestionCode);
            writer.WriteString("questionType", value.QuestionType.ToString());
            writer.WritePropertyName("answer");
            switch (value)
            {
                case TextQuestionAnswerDto text:
                    writer.WriteStringValue(text.Answer);
                    break;
                case NumericQuestionAnswerDto numeric:
                    writer.WriteNumberValue(numeric.Answer);
                    break;
                case ChoiceQuestionAnswerDto choice:
                    writer.WriteStringValue(choice.Answer);
                    break;
                default:
                    JsonSerializer.Serialize(writer, value.GetAnswer(), options);
                    break;
            }
            writer.WriteEndObject();
        }
    }
}
