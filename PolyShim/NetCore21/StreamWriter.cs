﻿#if (NETCOREAPP1_0_OR_GREATER && !NETCOREAPP2_1_OR_GREATER) || (NET20_OR_GREATER) || (NETSTANDARD1_0_OR_GREATER && !NETSTANDARD2_1_OR_GREATER)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

[ExcludeFromCodeCoverage]
internal static class _7675BF9AE7F8438E90FD20EB182575DA
{
#if FEATURE_MEMORY
    // https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter.write#system-io-streamwriter-write(system-readonlyspan((system-char)))
    public static void Write(this StreamWriter writer, ReadOnlySpan<char> buffer)
    {
        var bufferArray = buffer.ToArray();
        writer.Write(bufferArray, 0, bufferArray.Length);
    }
#endif

#if FEATURE_TASK && FEATURE_MEMORY
    // https://learn.microsoft.com/en-us/dotnet/api/system.io.streamwriter.writeasync#system-io-streamwriter-writeasync(system-readonlymemory((system-char))-system-threading-cancellationtoken)
    public static async Task WriteAsync(
        this StreamWriter writer,
        Memory<char> buffer,
        CancellationToken cancellationToken = default)
    {
        var bufferArray = buffer.ToArray();

        cancellationToken.ThrowIfCancellationRequested();
        await writer.WriteAsync(bufferArray, 0, bufferArray.Length).ConfigureAwait(false);
    }
#endif
}
#endif