namespace Microservices.Demo.Payments.Service.Infrastructure.Files
{
    public class BankStatementsFileReadingError : Exception
    {
        public BankStatementsFileReadingError(Exception ex) :
            base("Policy Account not found. BankStatementsFileReadingError", ex)
        {
        }
    }
}
