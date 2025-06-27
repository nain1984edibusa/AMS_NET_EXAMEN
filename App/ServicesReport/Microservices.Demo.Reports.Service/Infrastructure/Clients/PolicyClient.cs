using Microservices.Demo.Reports.Service.Application.Dtos;
using Microservices.Demo.Reports.Service.Application.Interfaces;

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

        public Task<List<PolicyDto>> GetPoliciesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPolicyDataAsync()
        {
            // Simula una llamada a policies.service
            return await Task.FromResult("Policy data from policies.service");
        }

        public Task<PolicyVersionDto> GetPolicyVersionAsync(string number)
        {
            throw new NotImplementedException();
        }
    }
}
