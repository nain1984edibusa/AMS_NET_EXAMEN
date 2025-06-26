using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Consumer
{
    public class HandlerNotRegisteredException : Exception
    {
        public HandlerNotRegisteredException(string message) : base(message) { }
    }

}
