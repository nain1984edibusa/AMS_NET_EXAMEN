using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Convertes
{    
    internal class QuestionAnswerDtoConverter : JsonConverter<QuestionAnswerDto>
    {
        public override QuestionAnswerDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();

            // --------- INICIO LOG JSON CRUDO ---------
            var readerCopy = reader;
            using (var doc = JsonDocument.ParseValue(ref readerCopy))
            {
                var rawJson = doc.RootElement.GetRawText();
                Console.WriteLine("JSON recibido en QuestionAnswerDtoConverter:");
                Console.WriteLine(rawJson);
            }
            // --------- FIN LOG JSON CRUDO ---------


            string questionCode = null;
            QuestionType? questionType = null;
            JsonElement answerElement = default;
                        
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                    break;

                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException();

                var propertyName = reader.GetString();
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
                        answerElement = JsonElement.ParseValue(ref reader);
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
                        Answer = answerElement.GetString()
                    };
                case QuestionType.Numeric:
                    return new NumericQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = answerElement.GetDecimal()
                    };
                case QuestionType.Choice:
                    return new ChoiceQuestionAnswerDto
                    {
                        QuestionCode = questionCode,
                        Answer = answerElement.GetString()
                    };
                default:
                    throw new JsonException($"Unexpected question type {questionType}");
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
                case NumericQuestionAnswerDto number:
                    writer.WriteNumberValue(number.Answer);
                    break;
                case ChoiceQuestionAnswerDto choice:
                    writer.WriteStringValue(choice.Answer);
                    break;
                default:
                    throw new JsonException($"Unknown type {value.GetType().Name}");
            }
            writer.WriteEndObject();
        }
    }

}
