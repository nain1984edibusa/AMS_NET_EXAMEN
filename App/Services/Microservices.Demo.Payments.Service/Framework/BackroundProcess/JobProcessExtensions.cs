using Hangfire;
using Hangfire.Logging.LogProviders;
using Hangfire.PostgreSql;
using Hangfire.Server;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Microservices.Demo.Payments.Service.Framework.Jobs
{
    public static class JobProcessExtensions
    {
        public static IServiceCollection AddJobs(this IServiceCollection services, IConfigurationManager configuration)
        {
            var jobsConfig= configuration.GetSection("BackgroundProcess").Get<BackgroundProcessConfig>();
            services.AddSingleton(jobsConfig);
            EnsureCreatedAsync(jobsConfig);

            services.AddHangfire(config =>
            {
                config.UsePostgreSqlStorage(jobsConfig.HangfireConnectionStringName);
                config.UseLogProvider(new ColouredConsoleLogProvider());
            });
            services.AddScoped<InPaymentRegistrationJob, InPaymentRegistrationJob>();
            services.AddHangfireServer();
            return services;
        }

        public static void UseJobs(this IApplicationBuilder app)
        {
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate<InPaymentRegistrationJob>(j => j.Run(), "*/1 * * * *");
        }

        private static async Task EnsureCreatedAsync(BackgroundProcessConfig config)
        {
            var builder = new NpgsqlConnectionStringBuilder(config.HangfireConnectionStringName);
            var dbName = builder.Database;

            builder.Database = "postgres";

            using (var conn = new NpgsqlConnection(builder.ToString()))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{dbName}'";
                    var exists = cmd.ExecuteScalar() != null;
                    if (!exists)
                    {
                        cmd.CommandText = $"CREATE DATABASE \"{dbName}\"";
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
