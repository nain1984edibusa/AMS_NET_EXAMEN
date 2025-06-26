using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

public class PolicyHolder: OfferHolder
{
    public PolicyHolder(string firstName, string lastName, string pesel, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Pesel = pesel;
        Address = address;
    }
    protected PolicyHolder()
    {
    }
    public virtual Address Address { get; protected set; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
        yield return Pesel;
        yield return Address;
    }
}