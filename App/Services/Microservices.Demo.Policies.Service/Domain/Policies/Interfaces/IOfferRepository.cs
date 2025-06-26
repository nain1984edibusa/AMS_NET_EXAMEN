using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.SharedKernel.Domain.Interfaces;

namespace Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;

public interface IOfferRepository : IRepository<Offer>
{    
    Task<Offer> WithNumber(string number);
}