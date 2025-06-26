using AutoMapper;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Request;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Responses;

using QuestionAnswerRestDto = Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos.QuestionAnswerDto;
using ChoiceQuestionAnswerRestDto = Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos.ChoiceQuestionAnswerDto;
using NumericQuestionAnswerRestDto = Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos.NumericQuestionAnswerDto;
using TextQuestionAnswerRestDto = Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos.TextQuestionAnswerDto;

using QuestionAnswerAppDto=Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos.QuestionAnswerDto;
using ChoiceQuestionAnswerAppDto = Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos.ChoiceQuestionAnswerDto;
using NumericQuestionAnswerAppDto = Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos.NumericQuestionAnswerDto;
using TextQuestionAnsweAppDto = Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos.TextQuestionAnsweDto;


namespace Microservices.Demo.Pricing.Service.Framework.Rest.Mappings
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<CalculatePriceRequest, CalculatePriceCommand>();
            CreateMap<CalculatePriceResult, CalculatePriceResponse>();

            CreateMap<QuestionAnswerRestDto, QuestionAnswerAppDto>()
                .Include<ChoiceQuestionAnswerRestDto, ChoiceQuestionAnswerAppDto>()
                .Include<NumericQuestionAnswerRestDto, NumericQuestionAnswerAppDto>()
                .Include<TextQuestionAnswerRestDto, TextQuestionAnsweAppDto>();

            CreateMap<ChoiceQuestionAnswerRestDto, ChoiceQuestionAnswerAppDto>();
            CreateMap<NumericQuestionAnswerRestDto, NumericQuestionAnswerAppDto>();
            CreateMap<TextQuestionAnswerRestDto, TextQuestionAnsweAppDto>();


        }
    }
}
