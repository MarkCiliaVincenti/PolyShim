﻿#if (NETFRAMEWORK && !NET471_OR_GREATER) || (NETSTANDARD && !NETSTANDARD1_6_OR_GREATER)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

using System.Collections.Generic;

namespace System.Linq;

internal static partial class PolyfillExtensions
{
    // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.prepend
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T element)
    {
        yield return element;

        foreach (var item in source)
            yield return item;
    }

    // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.append
    public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T element)
    {
        foreach (var item in source)
            yield return item;

        yield return element;
    }

#if (NETFRAMEWORK && !NET40_OR_GREATER)
    // https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.zip#system-linq-enumerable-zip-3(system-collections-generic-ienumerable((-0))-system-collections-generic-ienumerable((-1))-system-func((-0-1-2)))
    public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
        this IEnumerable<TFirst> first,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> resultSelector
    )
    {
        using var e1 = first.GetEnumerator();
        using var e2 = second.GetEnumerator();

        while (e1.MoveNext() && e2.MoveNext())
            yield return resultSelector(e1.Current, e2.Current);
    }
#endif
}
#endif
