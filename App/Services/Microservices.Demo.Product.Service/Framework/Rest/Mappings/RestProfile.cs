using AutoMapper;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode;

using Microservices.Demo.Products.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Products.Service.Framework.Rest.Models.Responses;

using CoverRestDto=Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos.CoverDto;
using ChoiceRestDto = Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos.ChoiceDto;
using QuestionRestDto = Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos.QuestionDto;
using ChoiceQuestionRestDto = Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos.ChoiceQuestionDto;
using DateQuestionRestDto = Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos.DateQuestionDto;
using NumericQuestionRestDto = Microservices.Demo.Products.Service.Framework.Rest.Models.Dtos.NumericQuestionDto;

using ProductAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.ProductDto;
using CoverAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.CoverDto;
using ChoiceAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.ChoiceDto;
using QuestionAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.QuestionDto;
using ChoiceQuestionAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.ChoiceQuestionDto;
using DateQuestionAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.DateQuestionDto;
using NumericQuestionAppDto = Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos.NumericQuestionDto;


namespace Microservices.Demo.Products.Service.Framework.Rest.Mappings
{
    public class RestProfile : Profile
    {
        public RestProfile()
        {
            CreateMap<GetAllProductsRequest, GetAllProductsQuery>();
            CreateMap<GetProductByCodeRequest, GetProductByCodeQuery>();
            CreateMap<CreateProductRequest,CreateProductCommand>();
            CreateMap<ActivateProductRequest, ActivateProductCommand>();
            CreateMap<DiscontinueProductRequest, DiscontinueProductCommand>();

            CreateMap<GetAllProductsResult, GetAllProductsResponse>();
            CreateMap<GetProductByCodeResult, GetProductByCodeResponse>();
            CreateMap<CreateProductResult, CreateProductResponse>();
            CreateMap<ActivateProductResult, ActivateProductResponse>();
            CreateMap<DiscontinueProductResult, DiscontinueProductResponse>();
                        
            CreateMap<CoverRestDto, CoverAppDto>();
            CreateMap<ChoiceRestDto, ChoiceAppDto>();
            CreateMap<QuestionRestDto, QuestionAppDto>()
                .Include<ChoiceQuestionRestDto, ChoiceQuestionAppDto>()
                .Include<DateQuestionRestDto, DateQuestionAppDto>()
                .Include<NumericQuestionRestDto, NumericQuestionAppDto>();
            CreateMap<ChoiceQuestionRestDto, ChoiceQuestionAppDto>();
            CreateMap<DateQuestionRestDto, DateQuestionAppDto>();
            CreateMap<NumericQuestionRestDto, NumericQuestionAppDto>();


            CreateMap<CoverAppDto, CoverRestDto>();
            CreateMap<ChoiceAppDto, ChoiceRestDto>();
            CreateMap<QuestionAppDto, QuestionRestDto>()
                .Include<ChoiceQuestionAppDto, ChoiceQuestionRestDto>()
                .Include<DateQuestionAppDto, DateQuestionRestDto>()
                .Include<NumericQuestionAppDto, NumericQuestionRestDto>();
            CreateMap<ChoiceQuestionAppDto, ChoiceQuestionRestDto>();
            CreateMap<DateQuestionAppDto, DateQuestionRestDto>();
            CreateMap<NumericQuestionAppDto, NumericQuestionRestDto>();

            CreateMap<ProductAppDto, ProductResponse>();
            CreateMap<GetAllProductsResult, GetAllProductsResponse>()
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.Products.Count()));
        }
    }
}
