﻿#if (NETCOREAPP && !NETCOREAPP2_0_OR_GREATER) || (NETFRAMEWORK) || (NETSTANDARD && !NETSTANDARD2_1_OR_GREATER)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// MatchCollection started implementing IEnumerable<Match> in .NET Core 2.0,
// but we can't implement an interface with extension methods.
// So the best we can do is provide some commonly used polyfills for IEnumerable<Match>.
internal static partial class PolyfillExtensions
{
    // https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.matchcollection.system-collections-generic-ienumerable-system-text-regularexpressions-match--getenumerator
    public static IEnumerable<Match> AsEnumerable(this MatchCollection matchCollection) =>
        matchCollection.Cast<Match>();

    public static IEnumerator<Match> GetEnumerator(this MatchCollection matchCollection) =>
        matchCollection.AsEnumerable().GetEnumerator();

    public static Match[] ToArray(this MatchCollection matchCollection) =>
        matchCollection.AsEnumerable().ToArray();
}
#endif
