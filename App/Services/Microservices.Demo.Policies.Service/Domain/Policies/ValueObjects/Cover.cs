using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects
{

    public class Cover : ValueObject, ICloneable
    {
        public Cover(string code, decimal price)
        {
            Code = code;
            Price = price;
        }

        protected Cover()
        {
        }

        public virtual string Code { get; protected set; }
        public virtual decimal Price { get; protected set; }


        object ICloneable.Clone()
        {
            return Clone();
        }

        public Cover Clone()
        {
            return new Cover(Code, Price);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Code;
            yield return Price;
        }
    }
}
