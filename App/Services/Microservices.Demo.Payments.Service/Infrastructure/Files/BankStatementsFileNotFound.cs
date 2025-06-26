namespace Microservices.Demo.Payments.Service.Infrastructure.Files
{

    public class BankStatementsFileNotFound : Exception
    {
        public BankStatementsFileNotFound(Exception ex) :
            base("Bank statements file not found.", ex)
        {
        }
    }
}
