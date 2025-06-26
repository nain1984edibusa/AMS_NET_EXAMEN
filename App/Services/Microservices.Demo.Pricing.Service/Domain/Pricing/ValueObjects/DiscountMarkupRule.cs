using DynamicExpresso;
using static System.String;
using static System.Decimal;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using System.Text.Json.Serialization;

namespace Microservices.Demo.Pricing.Service.Domain.Pricing.ValueObjects;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(PercentMarkupRule), typeDiscriminator: "PercentMarkupRule")]
public abstract class DiscountMarkupRule
{
    public string ApplyIfFormula { get; protected set; }
    public decimal ParamValue { get; protected set; }

    public bool Applies(Calculation calculation)
    {
        if (IsNullOrEmpty(ApplyIfFormula))
            return true;

        var (paramDefinitions, values) = calculation.ToCalculationParams();
        return (bool)new Interpreter()
            .Parse(ApplyIfFormula, paramDefinitions.ToArray())
            .Invoke(values.ToArray());
    }

    public abstract Calculation Apply(Calculation calculation);
}

public class PercentMarkupRule : DiscountMarkupRule
{
    public PercentMarkupRule(string applyIfFormula, decimal paramValue)
    {
        ApplyIfFormula = applyIfFormula;
        ParamValue = paramValue;
    }

    public override Calculation Apply(Calculation calculation)
    {
        foreach (var cover in calculation.Covers.Values)
        {
            var priceAfterMarkup = Round(cover.Price * ParamValue, 2);
            cover.SetPrice(priceAfterMarkup);
        }

        return calculation;
    }
}