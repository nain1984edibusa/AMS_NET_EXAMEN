namespace Microservices.Demo.Gateway.Framework.Web
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddAllowAllCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt => opt.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();

            }));

            return services;
        }

        public static IApplicationBuilder UseAllowAllCorsPolicy(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            return app;
        }
    }
}
