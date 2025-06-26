using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Enums;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos
{
    public class TextQuestionAnsweDto : QuestionAnswerModel<string>
    {
        public override QuestionType QuestionType => QuestionType.Text;
    }
}
