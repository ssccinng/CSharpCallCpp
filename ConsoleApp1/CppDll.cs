using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestDll
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct StringArray 
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public IntPtr[] vSupportValue;
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct StringArray2
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public string[] vSupportValue;
    }
    public struct StringStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string vSupportValue;
    }
    public struct CharArrayStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public char[] vSupportValue;
    }



    public static class CppDll
    {
        private const string DllPath = @"..\..\..\..\DllTest\x64\Release\DllTest.dll";

        [DllImport(DllPath)]
        extern public static int GetStringArray(ref StringArray stringArray);
        [DllImport(DllPath)]
        extern public static int GetStringArray2(ref StringArray2 stringArray);
        [DllImport(DllPath)]
        //[return: MarshalAs(UnmanagedType.LPStr)]
        extern public static IntPtr GetString();

        [DllImport(DllPath)]
        extern public static IntPtr GetCharPtr();



        [DllImport(DllPath)]
        extern public static int GetStringStruct(ref StringStruct stringStruct);

        [DllImport(DllPath)]
        extern public static int SendStringArray(string[] strings, int num);


    }
}
