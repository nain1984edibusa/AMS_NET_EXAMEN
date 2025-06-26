namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Responses
{
    public class GetAllPoliciesResponse
    {
        //public int Page { get; set; }
        //public int PageSize { get; set; }
        //public List<PolicyResponse> Policies { get; set; } = new List<PolicyResponse>();

        public List<Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos.PolicyDto> Policies { get; set; }
    }
}
