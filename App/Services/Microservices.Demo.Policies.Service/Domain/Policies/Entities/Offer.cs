using Microservices.Demo.Policies.Service.Domain.Policies.Enums;
using Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;
using Microservices.SharedKernel.Domain.Entities;
using Microservices.SharedKernel.Domain.Interfaces;
using Microservices.SharedKernel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microservices.Demo.Policies.Service.Domain.Policies.Entities;

public class Offer: Entity<Guid>, IAggregateRoot
{
    protected IList<Cover> covers = new List<Cover>();

    protected Offer(
        string productCode,
        DateTime policyFrom,
        DateTime policyTo,
        OfferHolder offerHolder,
        Price price,
        string agentLogin)
    {
        //Id = null;
        Number = Guid.NewGuid().ToString();
        ProductCode = productCode;
        PolicyValidityPeriod = ValidityPeriod.Between(policyFrom, policyTo);
        OfferHolder = offerHolder;
        covers = price.CoverPrices.Select(c => new Cover(c.Key, c.Value)).ToList();
        Status = OfferStatus.New;
        CreationDate = SysTime.CurrentTime;
        TotalPrice = price.CoverPrices.Sum(c => c.Value);
        AgentLogin = agentLogin;
    }

    protected Offer()
    {
    }

    //public virtual Guid? Id { get; protected set; }

    public virtual string Number { get; protected set; }

    public virtual string ProductCode { get; protected set; }

    public virtual ValidityPeriod PolicyValidityPeriod { get; protected set; }

    public virtual OfferHolder OfferHolder { get; protected set; }

    public virtual decimal TotalPrice { get; protected set; }

    public virtual OfferStatus Status { get; protected set; }

    public virtual DateTime CreationDate { get; protected set; }


    public virtual IReadOnlyCollection<Cover> Covers => new ReadOnlyCollection<Cover>(covers);

    public virtual string? AgentLogin { get; protected set; }

    public static Offer ForPrice(
        string productCode,
        DateTime policyFrom,
        DateTime policyTo,
        OfferHolder offerHolder,
        Price price)
    {
        return new Offer
        (
            productCode,
            policyFrom,
            policyTo,
            offerHolder,
            price,
            null
        );
    }

    public static Offer ForPriceAndAgent(
        string productCode,
        DateTime policyFrom,
        DateTime policyTo,
        OfferHolder offerHolder,
        Price price,
        string agent)
    {
        return new Offer
        (
            productCode,
            policyFrom,
            policyTo,
            offerHolder,
            price,
            agent
        );
    }

    public virtual Policy Buy(PolicyHolder customer)
    {
        if (IsExpired(SysTime.CurrentTime))
            throw new ApplicationException($"Offer {Number} has expired");

        if (Status != OfferStatus.New)
            throw new ApplicationException($"Offer {Number} is not in new status and cannot be bought");

        Status = OfferStatus.Converted;

        return Policy.FromOffer(customer, this);
    }

    public virtual bool IsExpired(DateTime theDate)
    {
        return CreationDate.AddDays(30) < theDate;
    }
}