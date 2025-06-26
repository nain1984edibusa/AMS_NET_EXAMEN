using Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests
{
    public class CreatePolicyRequest
    {
        public string OfferNumber { get; set; }
        public PersonDto PolicyHolder { get; set; }
        public AddressDto PolicyHolderAddress { get; set; }
    }
}
