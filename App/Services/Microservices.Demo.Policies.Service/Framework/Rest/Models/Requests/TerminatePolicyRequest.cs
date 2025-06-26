using Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests
{
    public class TerminatePolicyRequest
    {
        public string PolicyNumber { get; set; }
        public DateTime TerminationDate { get; set; }
    }
}
