// pch.h: 这是预编译标头文件。
// 下方列出的文件仅编译一次，提高了将来生成的生成性能。
// 这还将影响 IntelliSense 性能，包括代码完成和许多代码浏览功能。
// 但是，如果此处列出的文件中的任何一个在生成之间有更新，它们全部都将被重新编译。
// 请勿在此处添加要频繁更新的文件，这将使得性能优势无效。

#ifndef PCH_H
#define PCH_H

// 添加要在此处预编译的标头
#include "framework.h"

struct TestStruct {
    int Int1;
    unsigned char Byte1;
    int Int2;
    unsigned char Byte2;
    unsigned char Byte3;
	//const char* Str;
};

struct TestArrayStruct
{
	int Ints[10];
	bool Bools[10];
	TestStruct TestStructs[10];
	// 其他成员字段...
};


struct TestStringStruct
{
	char str[256];
	// 其他成员字段...
};

#ifdef __cplusplus
extern "C" {
#endif

	__declspec(dllexport) int GetInt();
	__declspec(dllexport) void SetInt(int i);

	__declspec(dllexport) char GetChar();
	// 这个字节数可能不一样..
	__declspec(dllexport) void SetChar(char c);

	__declspec(dllexport) short GetShort();
	__declspec(dllexport) void SetShort(short s);

	__declspec(dllexport) long long GetLong();
	__declspec(dllexport) void SetLong(long long l);

	__declspec(dllexport) float GetFloat();
	__declspec(dllexport) void SetFloat(float f);

	__declspec(dllexport) double GetDouble();
	__declspec(dllexport) void SetDouble(double d);


	// 尤其注意
	__declspec(dllexport) bool GetBool();
	__declspec(dllexport) void SetBool(bool b);

	__declspec(dllexport) void SetString(const char* str);
	__declspec(dllexport) const char* GetString();
	__declspec(dllexport) const char* GetString2();
	__declspec(dllexport) char* GetNewString();
	__declspec(dllexport) char* GetNewString2();

	__declspec(dllexport) void ModifyString(char* str, int len);

	__declspec(dllexport) void SetStringArray(const char** strArray, int count);
	__declspec(dllexport) char** GetStringArray(int* count);

	__declspec(dllexport) void SetIntArray(int* intArray, int count);
	__declspec(dllexport) int* GetIntArray(int* count);

	__declspec(dllexport) void SetBoolArray(bool* boolArray, int count);
	__declspec(dllexport) void GetBoolArray(bool* boolArray, int count);
	//__declspec(dllexport) bool* GetBoolArray2(int count);


	__declspec(dllexport) void ModifyInt(int* i);

	__declspec(dllexport) void ModifyStruct(TestStruct* s);
	__declspec(dllexport) void GetStructArray(TestStruct** s, int count);
	__declspec(dllexport) void GetStructArray1(TestStruct* s, int count);

	
	__declspec(dllexport) void ModifyArrayStruct(TestArrayStruct* s);
	__declspec(dllexport) void GetArrayStruct(TestArrayStruct* s);

	__declspec(dllexport) void CallCsFunc(int (*func)());





	__declspec(dllexport) const wchar_t* to_lower (const wchar_t* s);
	__declspec(dllexport) const char* to_lower1 (const char* s);
	__declspec(dllexport) int getStructString(TestStringStruct* s);







#ifdef __cplusplus
}

__declspec(dllexport) void CallCsFunc1(int a) {}
#endif


#endif //PCH_H
