﻿#if (NETCOREAPP1_0_OR_GREATER && !NET5_0_OR_GREATER) || (NET20_OR_GREATER) || (NETSTANDARD1_0_OR_GREATER)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

[ExcludeFromCodeCoverage]
internal static class _BC854DB33E934B03A5E2C3C3F205367B
{
#if FEATURE_TASK && FEATURE_HTTP
    // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstreamasync#system-net-http-httpclient-getstreamasync(system-string-system-threading-cancellationtoken)
    public static async Task<Stream> GetStreamAsync(
        this HttpClient httpClient,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        try
        {
            // Must not be disposed for the stream to be usable
            var response = await httpClient.GetAsync(
                requestUri,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);
        }
        // Older versions of HttpClient methods don't propagate the cancellation token inside the exception
        catch (OperationCanceledException ex) when (
            ex.CancellationToken != cancellationToken &&
            cancellationToken.IsCancellationRequested)
        {
            throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
        }
    }

    // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstreamasync#system-net-http-httpclient-getstreamasync(system-uri-system-threading-cancellationtoken)
    public static async Task<Stream> GetStreamAsync(
        this HttpClient httpClient,
        Uri requestUri,
        CancellationToken cancellationToken = default) =>
        await httpClient.GetStreamAsync(requestUri.ToString(), cancellationToken).ConfigureAwait(false);

    // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getbytearrayasync#system-net-http-httpclient-getbytearrayasync(system-string-system-threading-cancellationtoken)
    public static async Task<byte[]> GetByteArrayAsync(
        this HttpClient httpClient,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await httpClient.GetAsync(
                requestUri,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
        }
        // Older versions of HttpClient methods don't propagate the cancellation token inside the exception
        catch (OperationCanceledException ex) when (
            ex.CancellationToken != cancellationToken &&
            cancellationToken.IsCancellationRequested)
        {
            throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
        }
    }

    // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getbytearrayasync#system-net-http-httpclient-getbytearrayasync(system-uri-system-threading-cancellationtoken)
    public static async Task<byte[]> GetByteArrayAsync(
        this HttpClient httpClient,
        Uri requestUri,
        CancellationToken cancellationToken = default) =>
        await httpClient.GetByteArrayAsync(requestUri.ToString(), cancellationToken).ConfigureAwait(false);

    // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstringasync#system-net-http-httpclient-getstringasync(system-string-system-threading-cancellationtoken)
    public static async Task<string> GetStringAsync(
        this HttpClient httpClient,
        string requestUri,
        CancellationToken cancellationToken = default)
    {
        try
        {
            using var response = await httpClient.GetAsync(
                requestUri,
                HttpCompletionOption.ResponseHeadersRead,
                cancellationToken
            ).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
        }
        // Older versions of HttpClient methods don't propagate the cancellation token inside the exception
        catch (OperationCanceledException ex) when (
            ex.CancellationToken != cancellationToken &&
            cancellationToken.IsCancellationRequested)
        {
            throw new OperationCanceledException(ex.Message, ex.InnerException, cancellationToken);
        }
    }

    // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.getstringasync#system-net-http-httpclient-getstringasync(system-uri-system-threading-cancellationtoken)
    public static async Task<string> GetStringAsync(
        this HttpClient httpClient,
        Uri requestUri,
        CancellationToken cancellationToken = default) =>
        await httpClient.GetStringAsync(requestUri.ToString(), cancellationToken).ConfigureAwait(false);
#endif
}
#endif