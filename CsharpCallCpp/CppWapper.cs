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

        //[DllImport(_dllPath)]
        //public static extern nint GetString();
        //// 不推荐
        //[DllImport(_dllPath)]
        //public static extern string GetString2();
        /// <summary>
        /// 错误的！
        /// </summary>
        /// <returns></returns>
        [DllImport(_dllPath)]
        public static extern IntPtr GetNewString(); // char[] 
        //// 不推荐
        //[DllImport(_dllPath)]
        //public static extern string GetNewString2();
        [DllImport(_dllPath)]
        public static extern void SetString(string s);

        [DllImport(_dllPath)]
        public static extern void ModifyString(StringBuilder s, int len);
        [DllImport(_dllPath)]
        public static extern void ModifyString([In, Out] char[] s, int len);
        [DllImport(_dllPath)]
        public static extern void ModifyString(string s, int len);

        [DllImport(_dllPath)]
        public static extern void SetStringArray(string[] strArray, int count);

        //[DllImport(_dllPath)]
        //public static extern IntPtr GetStringArray(out int count);


        //public static extern void GetBoolArray(bool[] bools, int count); 错误示范


        [DllImport(_dllPath)]

        public static extern void GetBoolArray([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1), Out] bool[] bools, int count);

        /// <summary>
        /// 吃瘪操作
        /// </summary>
        /// <param name="bools"></param>
        /// <param name="count"></param>
        [DllImport(_dllPath)]
        public static extern void SetBoolArray([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] bool[] bools, int count);




        [DllImport(_dllPath)]
        public static extern void GetBoolArray([Out] byte[] bools, int count);
        [DllImport(_dllPath)]
        public static extern void SetBoolArray( byte[] bools, int count);

        [DllImport(_dllPath)]
        public static extern void ModifyInt(ref int i);

        [DllImport(_dllPath)]
        public static extern void ModifyStruct(ref TestStruct testStruct);

        [DllImport(_dllPath)]
        public static extern void ModifyStruct(ref TestStruct1 testStruct);
        [DllImport(_dllPath)]
        public static extern void GetStructArray(out TestStruct[] testStructs, int count);
        [DllImport(_dllPath)]
        public static extern void GetStructArray1([In, Out] TestStruct[] testStructs, int count);

        [DllImport(_dllPath)]
        public static extern void GetArrayStruct(out TestArrayStruct testStructs);

        [DllImport(_dllPath)]
        public static extern void CallCsFunc(TestWC func);

        public delegate int TestWC();
        // https://gist.github.com/GeeLaw/e29d5c52ed7114750eff2310900b50f5

        /// <summary>
        /// 第一次调用获取字符串长度，第二次传入指定大小的区域调用获取字符串, 返回值为错误码
        /// </summary>
        /// <param name="str"></param>
        /// <param name="conut"></param>
        //public static extern int GetString2(char[] str, ref int count); // 字符串不会超过128

    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]

    public struct TestStruct
    {
        public int Int1;
        public byte Byte1;
        public int Int2;
        public byte Byte2;
        public byte Byte3;

        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        //public string Str = "C";
    }


    [StructLayout(LayoutKind.Sequential, Pack = 2)]

    public struct TestStruct2
    {
        public int Int1;
        public byte Byte1;
        public int Int2;
        public byte Byte2;
        public byte Byte3;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct TestStruct1
    {
        public int Int1;
        public byte Byte1;
        public byte Byte1_1;
        public byte Byte1_2;
        public byte Byte1_3;
        public int Int2;
        public byte Byte2;
        public byte Byte3;
    }

    public struct TestArrayStruct
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public int[] Ints;
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.I1, SizeConst = 10)]
        public bool[] Bools;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public TestStruct[] TestStructs;

        // [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = 10)]

        // 不行哦
        //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.ByValTStr, SizeConst = 10)]
        //public string[] strings;
    }
}
