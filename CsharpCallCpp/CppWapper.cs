using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CsharpCallCpp
{
    public static class CppWapper
    {
        private const string _dllPath = @"..\..\..\..\..\DllTest\x64\Release\CppDll.dll";
        #region 基础数据类型

        [DllImport(_dllPath)]
        public static extern int GetInt();

        [DllImport(_dllPath)]
        public static extern void SetInt(int i);

        [DllImport(_dllPath)]
        public static extern char GetChar();

        [DllImport(_dllPath)]
        public static extern void SetChar(char c);

        [DllImport(_dllPath)]
        public static extern short GetShort();

        [DllImport(_dllPath)]
        public static extern void SetShort(short s);

        [DllImport(_dllPath)]
        public static extern long GetLong();

        [DllImport(_dllPath)]
        public static extern void SetLong(long l);

        [DllImport(_dllPath)]
        public static extern float GetFloat();

        [DllImport(_dllPath)]
        public static extern void SetFloat(float f);

        [DllImport(_dllPath)]
        public static extern double GetDouble();

        [DllImport(_dllPath)]
        public static extern void SetDouble(double d);

        [DllImport(_dllPath)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool GetBool();

        [DllImport(_dllPath)]
        public static extern void SetBool([MarshalAs(UnmanagedType.I1)] bool b);
        #endregion 

        [DllImport(_dllPath)]
        public static extern nint GetString();
        [DllImport(_dllPath)]
        public static extern void SetString(string s);

        [DllImport(_dllPath)]
        public static extern void ModifyString(StringBuilder s, int len);
        [DllImport(_dllPath)]
        public static extern void ModifyString(string s, int len);

        [DllImport(_dllPath)]
        public static extern void SetStringArray(string[] strArray, int count);

        [DllImport(_dllPath)]
        public static extern IntPtr GetStringArray(out int count);


        //public static extern void GetBoolArray(bool[] bools, int count); 错误示范


        [DllImport(_dllPath)]

        public static extern void GetBoolArray([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] bool[] bools, int count);

        /// <summary>
        /// 吃瘪操作
        /// </summary>
        /// <param name="bools"></param>
        /// <param name="count"></param>
        [DllImport(_dllPath)]
        public static extern void SetBoolArray([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] bool[] bools, int count);




        [DllImport(_dllPath)]
        public static extern void GetBoolArray(byte[] bools, int count);
        [DllImport(_dllPath)]
        public static extern void SetBoolArray(byte[] bools, int count);

        [DllImport(_dllPath)]
        public static extern void ModifyInt(ref int i);

        [DllImport(_dllPath)]
        public static extern void ModifyStruct(ref TestStruct testStruct);
        [DllImport(_dllPath)]
        public static extern void GetStructArray(out TestStruct[] testStructs, int count);

    }
    [StructLayout(LayoutKind.Sequential, Pack = 2)]

    public struct TestStruct
    {
        public int Int1;
        public byte Byte1;
        public int Int2;
        public byte Byte2;
        public byte Byte3;
    }
}
