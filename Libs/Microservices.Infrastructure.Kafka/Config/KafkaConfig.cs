using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Config
{
    public class KafkaConfig
    {
        public string BootstrapServers { get; set; }
        public ActorConfig Consumers { get; set; }
        public ActorConfig Producers { get; set; }
        public Persistence Persistence { get; set; }

        public KafkaConfig()
        {            
            Persistence = new Persistence();
        }
    }
}
