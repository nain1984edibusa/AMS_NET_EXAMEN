using System;
using System.Collections.Generic;

namespace Microservices.SharedKernel.Helpers;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        if (items == null)
            return;

        foreach (var item in items) action(item);
    }
}