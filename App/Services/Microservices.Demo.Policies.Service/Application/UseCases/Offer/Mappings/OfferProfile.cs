using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using OfferEntity = Microservices.Demo.Policies.Service.Domain.Policies.Entities.Offer;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Mappings
{
    public class OfferProfile : Profile
    {
        public OfferProfile()
        {
            CreateMap<CreateOfferCommand, CalculatePriceParamsDto>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src =>
                    src.Answers.Select(a =>
                        AnswerDto.Create(a.QuestionType, a.QuestionCode, a.GetAnswer())
                    ).ToList()
                ));
            

            CreateMap<OfferEntity, OfferDto>()
                .ForMember(dest => dest.OfferNumber, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.CoversPrices, opt => opt.MapFrom(src => src.Covers.ToDictionary(c => c.Code, c => c.Price)));

            CreateMap<OfferEntity, CreateOfferResult>().IncludeBase<OfferEntity, OfferDto>();
            CreateMap<OfferEntity, CreateOfferByAgentResult>().IncludeBase<OfferEntity, OfferDto>();
        }
    }
}
