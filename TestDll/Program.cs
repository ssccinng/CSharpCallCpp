// See https://aka.ms/new-console-template for more information
using System.Runtime.InteropServices;
using TestDll;

StringArray stringArray = new();
//CppDll.GetStringArray(ref stringArray);
var aa = CppDll.GetString();

// 强制修改字符串的话会怎么样
Console.WriteLine(Marshal.PtrToStringAnsi(aa));


StringStruct stringStruct = new();
var ret = CppDll.GetStringStruct(ref stringStruct);
Console.WriteLine(stringStruct.vSupportValue);

var bb = CppDll.GetCharPtr();

// 强制修改字符串的话会怎么样
Console.WriteLine(Marshal.PtrToStringAnsi(bb));

var asd = new string[] { "1", "2", "3" };
CppDll.SendStringArray(asd, 3);


StringArray2 stringArray2 = new();
stringArray2.vSupportValue = new string[128];
stringArray2.vSupportValue[0] = "123";
var cc = CppDll.GetStringArray2(ref stringArray2);
//Console.WriteLine(stringArray2.vSupportValue[0]);




return;
//Console.WriteLine(Marshal.PtrToStringAnsi(stringArray.vSupportValue[0]));
