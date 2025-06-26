using Microservices.Demo.Policies.Service.Framework.Rest.Endpoints;

namespace Microservices.Demo.Policies.Service.Framework.Web
{
    public static class EndpointExtensions
    {
        public static IEndpointRouteBuilder MapAllEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapOffersEndpoints();
            app.MapPoliciesEndpoints();
            return app;
        }
    }
}
