using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Handlers
{
    public static class ErrorsHandlers
    {
        public static Task<IResult> GetErrorsAsync(
            HttpContext httpContext
        )
        {
            var exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is ApplicationException)
            {
                return Task.FromResult<IResult>(Results.Problem(
                    title: "Business rules violation",
                    detail: exception.Message
                ));
            }

            return Task.FromResult<IResult>(Results.Problem());
        }
    }
}
