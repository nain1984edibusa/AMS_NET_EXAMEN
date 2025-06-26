using System.Text.Json.Serialization;
using System.Text.Json;
using Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Enums;

namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Converters
{
    public class QuestionDtoConverter : JsonConverter<QuestionDto>
    {
        public override QuestionDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Carga el objeto JSON completo
            using var doc = JsonDocument.ParseValue(ref reader);
            var root = doc.RootElement;

            if (!root.TryGetProperty("questionType", out var typeProp))
                throw new JsonException("Missing 'questionType' property");

            var typeName = typeProp.GetString();
            var questionType = Enum.Parse<QuestionType>(typeName, ignoreCase: true);

            switch (questionType)
            {
                case QuestionType.Date:
                    return JsonSerializer.Deserialize<DateQuestionDto>(root.GetRawText(), options);
                case QuestionType.Numeric:
                    return JsonSerializer.Deserialize<NumericQuestionDto>(root.GetRawText(), options);
                case QuestionType.Choice:
                    return JsonSerializer.Deserialize<ChoiceQuestionDto>(root.GetRawText(), options);
                default:
                    throw new JsonException($"Unknown question type: {typeName}");
            }
        }

        public override void Write(Utf8JsonWriter writer, QuestionDto value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("questionCode", value.QuestionCode);
            writer.WriteNumber("index", value.Index);
            writer.WriteString("questionType", value.QuestionType.ToString());
            writer.WriteString("text", value.Text);

            if (value is ChoiceQuestionDto choiceQuestion)
            {
                writer.WritePropertyName("choices");
                JsonSerializer.Serialize(writer, choiceQuestion.Choices, options);
            }

            writer.WriteEndObject();
        }
    }
}
