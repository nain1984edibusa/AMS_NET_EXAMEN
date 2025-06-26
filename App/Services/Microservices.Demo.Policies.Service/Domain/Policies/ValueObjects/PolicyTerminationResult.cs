using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.SharedKernel.Domain.ValueObjects;

namespace Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

public class PolicyTerminationResult : ValueObject
{
    public PolicyTerminationResult(PolicyVersion terminalVersion, decimal amountToReturn)
    {
        TerminalVersion = terminalVersion;
        AmountToReturn = amountToReturn;
    }

    public PolicyVersion TerminalVersion { get; }
    public decimal AmountToReturn { get; }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return TerminalVersion;
        yield return AmountToReturn;
    }
}