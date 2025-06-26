using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Trace
{
    public static class TracingActivityExtensions
    {
        public static void SetTagsFromObject(this Activity activity, object data, string prefix = null)
        {
            if (activity == null || data == null) return ;

            var properties = data.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                var value = prop.GetValue(data);
                if (value == null) continue;

                var type = prop.PropertyType;
                if (type.IsPrimitive || type == typeof(string) || type.IsEnum || type == typeof(Guid)
                    || type == typeof(DateTime) || type == typeof(decimal))
                {
                    var tagName = string.IsNullOrEmpty(prefix) ? prop.Name : $"{prefix}.{prop.Name}";
                    activity.SetTag(tagName, value.ToString());
                }
            }
        }

    }
}
