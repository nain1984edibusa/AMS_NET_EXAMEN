using Microservices.Demo.Policies.Search.Service.Framework.Rest.Endpoints;

namespace Microservices.Demo.Policies.Search.Service.Framework.Web
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPoliciesEndpoints();
            return app;
        }
    }
}
