﻿#if (NETCOREAPP && !NET7_0_OR_GREATER) || (NETFRAMEWORK) || (NETSTANDARD)
#nullable enable
// ReSharper disable RedundantUsingDirective
// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart

using System.Diagnostics.CodeAnalysis;

namespace System.Runtime.InteropServices;

// Unfortunately, the source generator that uses this attribute is only available on .NET 7 and above
// https://github.com/dotnet/runtime/issues/60595#issuecomment-1111086988

// https://learn.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.libraryimportattribute
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
[ExcludeFromCodeCoverage]
internal class LibraryImportAttribute : Attribute
{
    public string LibraryName { get; }

    public string? EntryPoint { get; init; }

    public bool SetLastError { get; init; }

    public StringMarshalling StringMarshalling { get; init; }

    public Type? StringMarshallingCustomType { get; init; }

    public LibraryImportAttribute(string libraryName) => LibraryName = libraryName;
}
#endif
