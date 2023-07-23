// See https://aka.ms/new-console-template for more information



#region 基础数据类型
using CsharpCallCpp;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

CppWapper.SetInt(1);
Console.WriteLine($"Get From Cpp: {CppWapper.GetInt()}");

CppWapper.SetChar('a');
Console.WriteLine($"Get From Cpp: {CppWapper.GetChar()}");

CppWapper.SetShort(2);
Console.WriteLine($"Get From Cpp: {CppWapper.GetShort()}");

CppWapper.SetLong(1L << 45);
Console.WriteLine($"Get From Cpp: {CppWapper.GetLong()}");

CppWapper.SetFloat(1.1f);
Console.WriteLine($"Get From Cpp: {CppWapper.GetFloat()}");

CppWapper.SetDouble(1.1);
Console.WriteLine($"Get From Cpp: {CppWapper.GetDouble()}");

#endregion

#region Bool    
CppWapper.SetBool(true);
Console.WriteLine($"Get From Cpp: {CppWapper.GetBool()}");
#endregion

#region 字符串

CppWapper.SetString("foo");
Console.WriteLine($"Get From Cpp: {Marshal.PtrToStringAnsi(CppWapper.GetString())}");

// 可行
StringBuilder modfiyString = new("sadasd");
CppWapper.ModifyString(modfiyString, modfiyString.Length);
Console.WriteLine($"Get modfiyString From Cpp: {modfiyString}");
// 不可行
string modfiyString1 = "sadasd";
CppWapper.ModifyString(modfiyString1, modfiyString.Length);
Console.WriteLine($"Get modfiyString1 From Cpp: {modfiyString1}");




string[] strArray = new string[] { "Hello", "World" };
CppWapper.SetStringArray(strArray, strArray.Length);


IntPtr strArrayPtr = CppWapper.GetStringArray(out int count);
string[] result = new string[count];
for (int i = 0; i < count; i++)
{
    IntPtr ptr = Marshal.ReadIntPtr(strArrayPtr, i * IntPtr.Size);
    result[i] = Marshal.PtrToStringAnsi(ptr);
    Console.WriteLine($"result[{i}]: {result[i]}");
}
Console.WriteLine(string.Join(", ", result));
#endregion

CppWapper.SetBoolArray(new bool[] { true, false, true }, 3);
bool[] bools = new bool[3];
CppWapper.GetBoolArray(bools, 3);
for (int i = 0; i < 3; i++)
{
    Console.WriteLine(bools[i]);
}


byte[] bytes = new byte[3];

CppWapper.SetBoolArray(new byte[] { 1, 0, 1 }, 3);
CppWapper.GetBoolArray(bytes, 3);
for (int i = 0; i < 3; i++)
{
    Console.WriteLine(bytes[i]);
}


int modInt = 0;
CppWapper.ModifyInt(ref modInt);
Console.WriteLine($"Modify int: {modInt}");

TestStruct testStruct = new TestStruct();
CppWapper.ModifyStruct(ref testStruct);
Console.WriteLine(JsonSerializer.Serialize(testStruct, new JsonSerializerOptions
{
    IncludeFields = true,
}));