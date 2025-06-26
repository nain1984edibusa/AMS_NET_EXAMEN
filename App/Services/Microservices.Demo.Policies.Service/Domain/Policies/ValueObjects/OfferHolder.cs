using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects
{
    public class OfferHolder: ValueObject
    {
        public OfferHolder(string firstName, string lastName, string pesel)
        {
            FirstName = firstName;
            LastName = lastName;
            Pesel = pesel;            
        }

        protected OfferHolder()
        {
        }

        public virtual string? FirstName { get; protected set; }
        public virtual string? LastName { get; protected set; }
        public virtual string? Pesel { get; protected set; }        

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return Pesel;            
        }
    }
}
