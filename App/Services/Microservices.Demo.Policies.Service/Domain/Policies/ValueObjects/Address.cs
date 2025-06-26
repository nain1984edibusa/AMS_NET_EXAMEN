using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

public class Address: ValueObject
{
    protected Address()
    {
    }

    public Address(string country, string zipCode, string city, string street)
    {
        Country = country;
        ZipCode = zipCode;
        City = city;
        Street = street;
    }

    public virtual string Country { get; protected set; }
    public virtual string ZipCode { get; protected set; }
    public virtual string City { get; protected set; }
    public virtual string Street { get; protected set; }

    public static Address Of(string country, string zipCode, string city, string street)
    {
        return new Address(country, zipCode, city, street);
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Country;
        yield return ZipCode;
        yield return City;
        yield return Street;
    }
    public Address Clone()
    {
        return new Address(Country, ZipCode, City, Street);
    }
}