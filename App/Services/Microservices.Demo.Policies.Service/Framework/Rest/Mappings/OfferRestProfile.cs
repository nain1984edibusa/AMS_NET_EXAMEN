using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Responses;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent;

using QuestionAnswerRestDto = Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos.QuestionAnswerDto;
using ChoiceQuestionAnswerRestDto = Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos.ChoiceQuestionAnswerDto;
using NumericQuestionAnswerRestDto = Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos.NumericQuestionAnswerDto;
using TextQuestionAnswerRestDto = Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos.TextQuestionAnswerDto;

using QuestionAnswerAppDto=Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.QuestionAnswerDto;
using ChoiceQuestionAnswerAppDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.ChoiceQuestionAnswerDto;
using NumericQuestionAnswerAppDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.NumericQuestionAnswerDto;
using TextQuestionAnswerAppDto = Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos.TextQuestionAnswerDto;

namespace Microservices.Demo.Products.Service.Framework.Rest.Mappings
{
    public class OfferRestProfile : Profile
    {
        public OfferRestProfile()
        {
            CreateMap<CreateOfferRequest, CreateOfferCommand>();

            CreateMap<QuestionAnswerRestDto, QuestionAnswerAppDto>()
                .Include<ChoiceQuestionAnswerRestDto, ChoiceQuestionAnswerAppDto>()
                .Include<NumericQuestionAnswerRestDto, NumericQuestionAnswerAppDto>()
                .Include<TextQuestionAnswerRestDto, TextQuestionAnswerAppDto>();

            CreateMap<ChoiceQuestionAnswerRestDto, ChoiceQuestionAnswerAppDto>();
            CreateMap<NumericQuestionAnswerRestDto, NumericQuestionAnswerAppDto>();
            CreateMap<TextQuestionAnswerRestDto, TextQuestionAnswerAppDto>();

            CreateMap<CreateOfferResult, CreateOfferResponse>();
            CreateMap<CreateOfferByAgentResult, CreateOfferByAgentResponse> ();
        }
    }
}
