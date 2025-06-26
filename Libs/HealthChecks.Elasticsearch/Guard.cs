using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HealthChecks.Elasticsearch
{
    internal static class Guard
    {        
        public static T ThrowIfNull<T>([NotNull] T? argument, bool throwOnEmptyString = false, [CallerArgumentExpression(nameof(argument))] string? paramName = null)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(argument, paramName);
            if (throwOnEmptyString && argument is string s && string.IsNullOrEmpty(s))
                throw new ArgumentNullException(paramName);

            return argument;
        }
    }

}
