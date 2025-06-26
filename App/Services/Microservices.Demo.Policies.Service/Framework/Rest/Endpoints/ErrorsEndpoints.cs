
using Microservices.Demo.Policies.Service.Framework.Rest.Handlers;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Endpoints
{
    public static class ErrorsEndpoints
    {
        public static void MapErrorsEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/errors").WithTags("Errors");

            group.Map("/", ErrorsHandlers.GetErrorsAsync).ExcludeFromDescription();
         
        }
    }
}
