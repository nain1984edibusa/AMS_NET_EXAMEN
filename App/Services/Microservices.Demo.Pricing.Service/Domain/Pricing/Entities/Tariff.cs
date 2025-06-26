using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Services;
using Microservices.Demo.Pricing.Service.Domain.Pricing.ValueObjects;
using Microservices.SharedKernel.Domain.Entities;
using Microservices.SharedKernel.Domain.Interfaces;
using Newtonsoft.Json;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;

public class Tariff : Entity<Guid>, IAggregateRoot
{
    [JsonProperty]
    private List<BasePremiumCalculationRule> basePremiumRules;

    [JsonProperty]
    private List<DiscountMarkupRule> discountMarkupRules;

    public Tariff(string code)
    {
        Id = Guid.NewGuid();
        Code = code;
        basePremiumRules = new List<BasePremiumCalculationRule>();
        discountMarkupRules = new List<DiscountMarkupRule>();
    }

    //public Guid Id { get; }
    public string Code { get; }

    [JsonIgnore] 
    public BasePremiumCalculationRuleList BasePremiumRules => new(basePremiumRules);

    [JsonIgnore] 
    public DiscountMarkupRuleList DiscountMarkupRules => new(discountMarkupRules);

    public Calculation CalculatePrice(Calculation calculation)
    {
        CalcBasePrices(calculation);
        ApplyDiscounts(calculation);
        UpdateTotals(calculation);
        return calculation;
    }


    private void CalcBasePrices(Calculation calculation)
    {
        foreach (var cover in calculation.Covers.Values)
            cover.SetPrice(BasePremiumRules.CalculateBasePriceFor(cover, calculation));
    }

    private void ApplyDiscounts(Calculation calculation)
    {
        DiscountMarkupRules.Apply(calculation);
    }

    private void UpdateTotals(Calculation calculation)
    {
        calculation.UpdateTotal();
    }
}