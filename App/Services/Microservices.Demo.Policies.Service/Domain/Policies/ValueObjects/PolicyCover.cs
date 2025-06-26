using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects
{
    public class PolicyCover: ValueObject
    {
        public PolicyCover(Cover cover, ValidityPeriod coverPeriod)
        {
            Code = cover.Code;
            Premium = cover.Price;
            CoverPeriod = coverPeriod;
        }

        protected PolicyCover()
        {
        }

        public virtual string Code { get; protected set; }
        public virtual decimal Premium { get; protected set; }
        public virtual ValidityPeriod CoverPeriod { get; protected set; }

        public PolicyCover EndOn(DateTime endDate)
        {
            var originalDaysCovered = CoverPeriod.Days;
            var daysNotUsed = originalDaysCovered - CoverPeriod.EndOn(endDate).Days;
            var premium = decimal.Round
            (
                Premium - Premium * decimal.Divide(daysNotUsed, originalDaysCovered)
                , 2
            );

            return new PolicyCover
            {
                Code = Code,
                Premium = premium,
                CoverPeriod = CoverPeriod.EndOn(endDate)
            };
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Code;
            yield return Premium;
            yield return CoverPeriod;
        }
    }
}
