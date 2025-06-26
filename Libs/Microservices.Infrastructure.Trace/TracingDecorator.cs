using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Trace
{
    public class TracingDecorator<T> : DispatchProxy where T : class
    {
        private T _decorated;
        private ActivitySource _source;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            using var activity = _source.StartActivity($"{typeof(T).Name}.{targetMethod.Name}", ActivityKind.Internal);

            try
            {
                var result = targetMethod.Invoke(_decorated, args);
                activity.SetStatus(ActivityStatusCode.Ok);
                return result;
            }
            catch (Exception ex)
            {
                activity.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity.RecordException(ex);
                throw;
            }
        }

        public static T Create(T decorated, ActivitySource source)
        {
            object proxy = Create<T, TracingDecorator<T>>();
            ((TracingDecorator<T>)proxy)._decorated = decorated;
            ((TracingDecorator<T>)proxy)._source = source;
            return (T)proxy;
        }
    }

}
