using Microservices.Demo.Reports.Service.Application.Dtos;
using Microservices.Demo.Reports.Service.Application.Interfaces;
using System.Text.Json;

namespace Microservices.Demo.Reports.Service.Infrastructure.Clients
{
    public class PolicyClient : IPolicyClient
    {
        private readonly HttpClient _httpClient;

        public PolicyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<PolicyDto> GetDetPolicyAsync(string number)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PolicyDto>> GetPoliciesAsync()
        {
            //var response = await _httpClient.GetAsync("/api/policies");
            //response.EnsureSuccessStatusCode();
            //var json = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("JSON recibido:");
            //Console.WriteLine(json);

            //return JsonSerializer.Deserialize<List<PolicyDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

            var response = await _httpClient.GetAsync("api/policies");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var policiesWrapper = JsonSerializer.Deserialize<PoliciesResponseDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return policiesWrapper?.Policies ?? new List<PolicyDto>();
        }

        public async Task<PolicyVersionDto?> GetPolicyVersionAsync(string policyId)
        {
            var response = await _httpClient.GetAsync($"/api/policies/by-id/{policyId}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PolicyVersionDto>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


    }
}
