namespace Microservices.Demo.Payments.Service.Domain.Payments.Dtos
{
    public class BankStatement
    {
        public BankStatement(string accountNumber, string amountAsString, string accountingDateAsIsoDateString)
        {
            AccountNumber = accountNumber;
            Amount = decimal.Parse(amountAsString);
            AccountingDate = DateTimeOffset.Parse(accountingDateAsIsoDateString);
        }

        public string AccountNumber { get; }
        public decimal Amount { get; }
        public DateTimeOffset AccountingDate { get; }
    }
}
