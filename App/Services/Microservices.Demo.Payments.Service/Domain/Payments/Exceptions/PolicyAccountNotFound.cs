namespace Microservices.Demo.Payments.Service.Domain.Payments.Exceptions
{
    public class PolicyAccountNotFound : BussinesExceptions
    {
        public PolicyAccountNotFound(string accountNumber) :
            base($"Policy Account not found. Looking for account with number: {accountNumber}")
        {
        }
    }
}
