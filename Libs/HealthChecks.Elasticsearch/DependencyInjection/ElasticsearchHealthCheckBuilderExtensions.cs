using HealthChecks.Elasticsearch;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Microsoft.Extensions.DependencyInjection;

public static class ElasticsearchHealthCheckBuilderExtensions
{
    private const string NAME = "elasticsearch";
        
    public static IHealthChecksBuilder AddElasticsearch(
        this IHealthChecksBuilder builder,
        string elasticsearchUri,
        string? name = default,
        HealthStatus? failureStatus = default,
        IEnumerable<string>? tags = default,
        TimeSpan? timeout = default)
    {
        var options = new ElasticsearchOptions();
        options.UseServer(elasticsearchUri);
        return builder.Add(new HealthCheckRegistration(
            name ?? NAME,
            sp => new ElasticsearchHealthCheck(options),
            failureStatus,
            tags,
            timeout));
    }

    public static IHealthChecksBuilder AddElasticsearch(
        this IHealthChecksBuilder builder,
        Action<ElasticsearchOptions>? setup,
        string? name = default,
        HealthStatus? failureStatus = default,
        IEnumerable<string>? tags = default,
        TimeSpan? timeout = default)
    {
        var options = new ElasticsearchOptions();
        setup?.Invoke(options);

        options.RequestTimeout ??= timeout;

        if (options.Uri is null && !options.AuthenticateWithElasticCloud)
        {
            throw new InvalidOperationException($"there is no server to connect. consider using ${nameof(ElasticsearchOptions.UseElasticCloud)} or ${nameof(ElasticsearchOptions.UseServer)}");
        }

        return builder.Add(new HealthCheckRegistration(
            name ?? NAME,
            sp => new ElasticsearchHealthCheck(options),
            failureStatus,
            tags,
            timeout));
    }
    public static IHealthChecksBuilder AddElasticsearch(
        this IHealthChecksBuilder builder,
        Func<IServiceProvider, Elastic.Clients.Elasticsearch.ElasticsearchClient>? clientFactory = null,
        string? name = default,
        HealthStatus? failureStatus = default,
        IEnumerable<string>? tags = default,
        TimeSpan? timeout = default)
    {

        return builder.Add(new HealthCheckRegistration(
            name ?? NAME,
            sp =>
            {
                ElasticsearchOptions options = new()
                {
                    RequestTimeout = timeout,
                    Client = clientFactory?.Invoke(sp) ?? sp.GetRequiredService<Elastic.Clients.Elasticsearch.ElasticsearchClient>()
                };


                return new ElasticsearchHealthCheck(options);
            },
            failureStatus,
            tags,
            timeout));
    }
}
