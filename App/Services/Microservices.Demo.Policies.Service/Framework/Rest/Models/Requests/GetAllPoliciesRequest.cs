namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests
{
    public class GetAllPoliciesRequest
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? Search { get; set; }
    }
}
