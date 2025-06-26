using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Trace
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TraceAttribute : Attribute { }

}
