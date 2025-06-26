namespace Microservices.Demo.Payments.Service.Domain.Payments.Exceptions
{
    public class BussinesExceptions : Exception
    {
        public BussinesExceptions(string message) :
            base(message)
        {
        }

        public BussinesExceptions(string message, Exception ex) :
            base(message, ex)
        {
        }
    }
}
