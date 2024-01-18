using CsharpCallCpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

internal static partial class CppWapperHelpers
{
    // https://gist.github.com/GeeLaw/e29d5c52ed7114750eff2310900b50f5
    private const string _dllPath = @"..\..\..\..\..\DllTest\x64\Release\CppDll.dll";

    [LibraryImport(
        _dllPath,
        EntryPoint = "to_lower", StringMarshalling = StringMarshalling.Utf16)]
           
            internal static partial string ToLower(
        string str);


    [LibraryImport(
    _dllPath,
    EntryPoint = "to_lower1", StringMarshalling = StringMarshalling.Utf8)]

    internal static partial string ToLower1(
    string str);
}