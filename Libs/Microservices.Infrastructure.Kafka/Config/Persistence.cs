using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Config
{
    public class Persistence
    {
        public bool Enabled { get; set; }
        public Box Outbox { get; set; }
    }
}
