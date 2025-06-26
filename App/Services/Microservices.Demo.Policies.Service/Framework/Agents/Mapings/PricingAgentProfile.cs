using AutoMapper;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos;
using Microservices.Demo.RestClients.Pricing.Models.Requests;

using CmdAnswerDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.AnswerDto;
using CmdTextAnswerDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.TextAnswerDto;
using CmdChoiceAnswerDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.ChoiceAnswerDto;
using CmdNumericAnswerDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.NumericAnswerDto;

using RestQuestionAnswerDto = Microservices.Demo.RestClients.Pricing.Models.Dtos.QuestionAnswerDto;
using RestTextQuestionAnswerDto = Microservices.Demo.RestClients.Pricing.Models.Dtos.TextQuestionAnswerDto;
using RestChoiceQuestionAnswerDto = Microservices.Demo.RestClients.Pricing.Models.Dtos.ChoiceQuestionAnswerDto;
using RestNumericQuestionAnswerDto = Microservices.Demo.RestClients.Pricing.Models.Dtos.NumericQuestionAnswerDto;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;


namespace Microservices.Demo.Policies.Service.Framework.Agents.Mapings
{
    public class PricingAgentProfile : Profile
    {
        public PricingAgentProfile()
        {
            CreateMap<CmdAnswerDto, RestQuestionAnswerDto>()
            .Include<CmdTextAnswerDto, RestTextQuestionAnswerDto>()
            .Include<CmdChoiceAnswerDto, RestChoiceQuestionAnswerDto>()
            .Include<CmdNumericAnswerDto, RestNumericQuestionAnswerDto>();

            CreateMap<CmdTextAnswerDto, RestTextQuestionAnswerDto>()
                .ForMember(dest => dest.QuestionCode, opt => opt.MapFrom(src => src.QuestionCode))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => (string)src.GetAnswerValue()));

            CreateMap<CmdChoiceAnswerDto, RestChoiceQuestionAnswerDto>()
                .ForMember(dest => dest.QuestionCode, opt => opt.MapFrom(src => src.QuestionCode))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => (string)src.GetAnswerValue()));

            CreateMap<CmdNumericAnswerDto, RestNumericQuestionAnswerDto>()
                .ForMember(dest => dest.QuestionCode, opt => opt.MapFrom(src => src.QuestionCode))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => (decimal)src.GetAnswerValue()));


            CreateMap<List<CmdAnswerDto>, List<RestQuestionAnswerDto>>()
              .ConvertUsing((src, dest, context) =>
                  src.Select(a => context.Mapper.Map<RestQuestionAnswerDto>(a)).ToList());


            CreateMap<CalculatePriceParamsDto, CalculatePriceRequest>();
        }
    }
}
