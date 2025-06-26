using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Domain.Policies.Entities;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent
{
    public class CreateOfferByAgentCommand : CreateOfferCommand
    {
        public CreateOfferByAgentCommand(string agentLogin, CreateOfferCommand baseCmd)
        {
            AgentLogin = agentLogin;
            ProductCode = baseCmd.ProductCode;
            PolicyFrom = baseCmd.PolicyFrom;
            PolicyTo = baseCmd.PolicyTo;
            SelectedCovers = baseCmd.SelectedCovers;
            Answers = baseCmd.Answers;
        }

        public string AgentLogin { get; set; }
    }
}
