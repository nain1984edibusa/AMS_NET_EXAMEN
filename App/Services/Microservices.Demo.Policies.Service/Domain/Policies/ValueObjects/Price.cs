using Microservices.SharedKernel.Domain.ValueObjects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

public class Price: ValueObject
{
    private readonly Dictionary<string, decimal> coverPrices;

    public Price(Dictionary<string, decimal> coverPrices)
    {
        this.coverPrices = coverPrices;
    }

    public IReadOnlyDictionary<string, decimal> CoverPrices => new ReadOnlyDictionary<string, decimal>(coverPrices);

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return coverPrices;
        foreach (var kvp in coverPrices)
        {
            yield return kvp.Key;
            yield return kvp.Value;
        }
    }
}