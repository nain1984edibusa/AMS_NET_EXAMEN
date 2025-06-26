using AutoMapper;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Interfaces;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode;
using Microservices.Demo.Products.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Products.Service.Framework.Rest.Models.Responses;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Microservices.Demo.Products.Service.Framework.Rest.Endpoints
{
    public static class ProductsHandlers
    {
        public static async Task<IResult> GetAllProductsAsync(
           [FromServices] IMapper _mapper,
           [FromServices] IProductApplicationService _service,
           [AsParameters] GetAllProductsRequest request
        )
        {
            var query = _mapper.Map<GetAllProductsQuery>(request);
            var result = await _service.GetAllProducts.ExecuteAsync(query);

            var response = _mapper.Map<GetAllProductsResponse>(result);

            return Results.Ok(response);
        }
        public static async Task<IResult> GetProductByCodeAsync(
            [FromServices] IMapper _mapper,
            [FromServices] IProductApplicationService _service,
            [AsParameters] GetProductByCodeRequest request            
        )
        {
            var result = await _service.GetProductByCode.ExecuteAsync(_mapper.Map<GetProductByCodeQuery>(request));
            return result is not null ? Results.Ok(_mapper.Map<GetProductByCodeResponse>(result)) : Results.NotFound();
        }
        public static async Task<IResult> CreateProductAsync(
            [FromServices] IMapper _mapper,
            [FromServices] IProductApplicationService _service,
            [FromBody] CreateProductRequest request
        )
        {
            var command = _mapper.Map<CreateProductCommand>(request);
            var result = await _service.CreateProduct.ExecuteAsync(command);
            return Results.Created($"/api/products/{result.Id}", _mapper.Map<CreateProductResponse>(result));
        }
        public static async Task<IResult> ActivateProductAsync(
            [FromServices] IMapper _mapper,
            [FromServices] IProductApplicationService _service,
            [FromBody] ActivateProductRequest request
        )
        {
            var command = _mapper.Map<ActivateProductCommand>(request);
            var result = await _service.ActivateProduct.ExecuteAsync(command);
            return result is not null ? Results.Ok(_mapper.Map<ActivateProductResponse>(result)) : Results.NotFound();
        }
        public static async Task<IResult> DiscontinueProductAsync(
            [FromServices] IMapper _mapper,
            [FromServices] IProductApplicationService _service,
            [FromBody] DiscontinueProductRequest request
        )
        {
            var command = _mapper.Map<DiscontinueProductCommand>(request);
            var result = await _service.DiscontinueProduct.ExecuteAsync(command);
            return result is not null ? Results.Ok(_mapper.Map<DiscontinueProductResponse>(result)) : Results.NotFound();
        }
    }
}
