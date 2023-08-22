﻿#if (NETCOREAPP && !NETCOREAPP2_0_OR_GREATER) || (NETFRAMEWORK) || (NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

namespace System.Collections.Generic;

internal static partial class PolyfillExtensions
{
    // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.collectionextensions.getvalueordefault#system-collections-generic-collectionextensions-getvalueordefault-2(system-collections-generic-ireadonlydictionary((-0-1))-0-1)
    public static TValue? GetValueOrDefault<TKey, TValue>(
#if NETFRAMEWORK && !NET45_OR_GREATER
        this IDictionary<TKey, TValue> dictionary,
#else
        this IReadOnlyDictionary<TKey, TValue> dictionary,
#endif
        TKey key,
        TValue? defaultValue
    ) => dictionary.TryGetValue(key, out var value) ? value : defaultValue;

    // https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.collectionextensions.getvalueordefault#system-collections-generic-collectionextensions-getvalueordefault-2(system-collections-generic-ireadonlydictionary((-0-1))-0)
    public static TValue? GetValueOrDefault<TKey, TValue>(
#if NETFRAMEWORK && !NET45_OR_GREATER
        this IDictionary<TKey, TValue> dictionary,
#else
        this IReadOnlyDictionary<TKey, TValue> dictionary,
#endif
        TKey key
    ) => dictionary.GetValueOrDefault(key, default);
}
#endif
