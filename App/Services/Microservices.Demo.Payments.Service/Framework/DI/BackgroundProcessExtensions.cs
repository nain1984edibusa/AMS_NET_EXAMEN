using Hangfire;
using Microservices.Demo.Payments.Service.Framework.Jobs;

namespace Microservices.Demo.Payments.Service.Framework.DI
{
    public static class BackgroundProcessExtensions
    {
        public static IServiceCollection AddBackgroundProcess(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddJobs(configuration);

            return services;
        }

        public static void UseBackgroundProcess(this IApplicationBuilder app)
        {
            app.UseJobs();
        }
    }
}
