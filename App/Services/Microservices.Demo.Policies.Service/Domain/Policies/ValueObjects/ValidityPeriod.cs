using Microservices.SharedKernel.Domain.ValueObjects;
using System;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

public class ValidityPeriod : ValueObject, ICloneable
{
    public ValidityPeriod(DateTime validFrom, DateTime validTo)
    {
        ValidFrom = validFrom;
        ValidTo = validTo;
    }

    protected ValidityPeriod()
    {
    }

    public virtual DateTime ValidFrom { get; protected set; }
    public virtual DateTime ValidTo { get; protected set; }

    public int Days => ValidTo.Subtract(ValidFrom).Days;

    object ICloneable.Clone()
    {
        return Clone();
    }

    public static ValidityPeriod Between(DateTime validFrom, DateTime validTo)
    {
        return new ValidityPeriod(validFrom, validTo);
    }

    public ValidityPeriod Clone()
    {
        return new ValidityPeriod(ValidFrom, ValidTo);
    }

    public bool Contains(DateTime theDate)
    {
        if (theDate > ValidTo)
            return false;

        if (theDate < ValidFrom)
            return false;

        return true;
    }

    public ValidityPeriod EndOn(DateTime endDate)
    {
        return new ValidityPeriod(ValidFrom, endDate);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ValidFrom;
        yield return ValidTo;
    }
}