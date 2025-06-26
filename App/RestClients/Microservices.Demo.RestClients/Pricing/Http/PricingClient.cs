using Microservices.Demo.RestClients.Pricing.Http;
using Microservices.Demo.RestClients.Pricing.Models.Converters;
using Microservices.Demo.RestClients.Pricing.Models.Requests;
using Microservices.Demo.RestClients.Pricing.Models.Response;
using Microservices.Infrastructure.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Polly;
using Polly.Retry;
using RestEase;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery;
using System.Net.Http;

namespace Microservices.Demo.RestClients.Pricing.Http
{
    public class PricingClient : IPricingClient
    {
        private static readonly AsyncRetryPolicy _retryPolicy = Policy
            .Handle<HttpRequestException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(3));

        private readonly IPricingClient _client;
                
        public PricingClient(
            IConfiguration configuration,
            IDiscoveryClient discoveryClient,
            IUrlService urlService)
            : this(CreateDefaultHttpClient(discoveryClient, urlService.GetUrl("Pricing")), GetDefaultSerializerSettings())
        { }
                
        public PricingClient(HttpClient httpClient, JsonSerializerSettings settings)
        {
            var restClient = new RestClient(httpClient)
            {
                JsonSerializerSettings = settings
            };

            _client = restClient.For<IPricingClient>();
        }

        public Task<CalculatePriceResponse> CalculatePrice([Body] CalculatePriceRequest req)
        {
            return _retryPolicy.ExecuteAsync(() => _client.CalculatePrice(req));
        }

        
        private static HttpClient CreateDefaultHttpClient(IDiscoveryClient discoveryClient, string baseAddress)
        {
            var handler = new DiscoveryHttpClientHandler(discoveryClient);
            return new HttpClient(handler, false)
            {
                BaseAddress = new Uri(baseAddress)
            };
        }

        private static JsonSerializerSettings GetDefaultSerializerSettings()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };            
            settings.Converters.Add(new QuestionAnswerDtoConverter());

            return settings;
        }
    }
}
