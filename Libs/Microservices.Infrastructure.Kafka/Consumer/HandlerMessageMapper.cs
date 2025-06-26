using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Kafka.Consumer
{
    public class HandlerMessageMapper : IHandlerMessageMapper
    {
        private readonly HashSet<Assembly> _assemblies = new();
        public void AddHandlerMessage<THandlerMessage>()
        {
            _assemblies.Add(typeof(THandlerMessage).Assembly);
        }

        public IEnumerable<Assembly> GetAssemblies() => _assemblies;
    }
}
