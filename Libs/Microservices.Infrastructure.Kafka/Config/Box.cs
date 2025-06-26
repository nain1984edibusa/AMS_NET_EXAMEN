using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Config
{
    public class Box
    {
        public string MessagingConnection { get; set; }
        public string TableName { get; set; }
        public bool DisableLogs { get; set; }
    }
}
