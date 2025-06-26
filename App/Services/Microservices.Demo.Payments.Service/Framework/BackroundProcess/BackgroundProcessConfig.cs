namespace Microservices.Demo.Payments.Service.Framework.Jobs
{
    public class BackgroundProcessConfig
    {
        public string HangfireConnectionStringName { get; set; }
        public string InPaymentFileFolder { get; set; }
    }
}
