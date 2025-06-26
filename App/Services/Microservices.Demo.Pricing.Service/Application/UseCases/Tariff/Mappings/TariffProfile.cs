using AutoMapper;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Mappings
{
    public class TariffProfile:Profile
    {
        public TariffProfile()
        {
            CreateMap<CalculatePriceCommand, Calculation>()
                .ConstructUsing(cmd => new Calculation(
                    cmd.ProductCode,
                    cmd.PolicyFrom,
                    cmd.PolicyTo,
                    cmd.SelectedCovers,
                    cmd.Answers.ToDictionary(a => a.QuestionCode, a => a.GetAnswer())
                ));


            CreateMap<Calculation, CalculatePriceResult>()
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPremium))
                .ForMember(dest => dest.CoverPrices,
                    opt => opt.MapFrom(src => src.Covers.ToDictionary(c => c.Key, c => c.Value.Price)));
        }
    }
}
