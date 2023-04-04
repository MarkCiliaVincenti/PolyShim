﻿#if (NETCOREAPP1_0_OR_GREATER && !NETCOREAPP3_0_OR_GREATER) || (NET20_OR_GREATER) || (NETSTANDARD1_0_OR_GREATER && !NETSTANDARD2_1_OR_GREATER)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using System.Diagnostics.CodeAnalysis;

namespace System;

// https://learn.microsoft.com/en-us/dotnet/api/system.range
[ExcludeFromCodeCoverage]
internal readonly struct Range : IEquatable<Range>
{
    public Index Start { get; }

    public Index End { get; }

    public Range(Index start, Index end)
    {
        Start = start;
        End = end;
    }

#if FEATURE_VALUETUPLE
    public (int Offset, int Length) GetOffsetAndLength(int length)
    {
        var start = Start.IsFromEnd
            ? length - Start.Value
            : Start.Value;

        var end = End.IsFromEnd
            ? length - End.Value
            : End.Value;

        if ((uint)end > (uint)length || (uint)start > (uint)end)
            throw new ArgumentOutOfRangeException(nameof(length));

        return (start, end - start);
    }
#endif

    public override bool Equals(object? value) =>
        value is Range r &&
        r.Start.Equals(Start) &&
        r.End.Equals(End);

    public bool Equals(Range other) => other.Start.Equals(Start) && other.End.Equals(End);

    public override int GetHashCode() => Start.GetHashCode() * 31 + End.GetHashCode();

    public override string ToString() => Start + ".." + End;

    public static Range StartAt(Index start) => new(start, Index.End);

    public static Range EndAt(Index end) => new(Index.Start, end);

    public static Range All => new(Index.Start, Index.End);
}
#endif