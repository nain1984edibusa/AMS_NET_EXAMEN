using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Payments.Service.Domain.Payments.ValueObjects
{
    public class Owner:ValueObject
    {
        protected Owner()
        {
        }

        public Owner(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
