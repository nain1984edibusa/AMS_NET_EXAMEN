using AutoMapper;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using ProductEntity=Microservices.Demo.Products.Service.Domain.Products.Entities.Product;
using CoverEntity = Microservices.Demo.Products.Service.Domain.Products.Entities.Cover;
using QuestionEntity = Microservices.Demo.Products.Service.Domain.Products.Entities.Question;
using ChoiceQuestionEntity = Microservices.Demo.Products.Service.Domain.Products.Entities.ChoiceQuestion;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>()
                .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => src.ProductIcon))
                .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.Questions.Select(q => ToQuestionDto(q)).ToList()));

            CreateMap<CoverEntity, CoverDto>();
           

            CreateMap<ProductEntity, CreateProductResult>().IncludeBase<ProductEntity, ProductDto>();
            CreateMap<ProductEntity, ActivateProductResult>().IncludeBase<ProductEntity, ProductDto>();
            CreateMap<ProductEntity, DiscontinueProductResult>().IncludeBase<ProductEntity, ProductDto>();
            CreateMap<ProductEntity, GetProductByCodeResult>().IncludeBase<ProductEntity,ProductDto>();
            CreateMap<List<ProductEntity>, GetAllProductsResult>()
               .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));


        }

        private QuestionDto ToQuestionDto(QuestionEntity question)
        {
            switch (question.GetType().Name)
            {
                case "NumericQuestion":
                    return new NumericQuestionDto
                    { QuestionCode = question.Code, Index = question.Index, Text = question.Text };
                case "ChoiceQuestion":
                    return new ChoiceQuestionDto
                    {
                        QuestionCode = question.Code,
                        Index = question.Index,
                        Text = question.Text,
                        Choices = ((ChoiceQuestionEntity)question).Choices
                            ?.Select(c => new ChoiceDto { Code = c.Code, Label = c.Label }).ToList()
                    };
                case "DateQuestion":
                    return new DateQuestionDto
                    { QuestionCode = question.Code, Index = question.Index, Text = question.Text };

                default:
                    throw new ArgumentOutOfRangeException(question.GetType().Name);
            }
        }
    }
}
