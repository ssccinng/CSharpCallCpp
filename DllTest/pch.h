// pch.h: 这是预编译标头文件。
// 下方列出的文件仅编译一次，提高了将来生成的生成性能。
// 这还将影响 IntelliSense 性能，包括代码完成和许多代码浏览功能。
// 但是，如果此处列出的文件中的任何一个在生成之间有更新，它们全部都将被重新编译。
// 请勿在此处添加要频繁更新的文件，这将使得性能优势无效。

#ifndef PCH_H
#define PCH_H

// 添加要在此处预编译的标头
#include "framework.h"
#include <iostream>
#include <vector>

//using namespace std;

struct EnumValueInfo_C
{
	char sCurValue[128];
	int vSupportValueSize;
	char vSupportValue[64][128];
};

struct StringArray {
	char vSupportValue[128][128];
};
struct String2Array {
	char** vSupportValue;
};

struct StringStruct {
	char vSupportValue[128];
};

#ifdef __cplusplus
extern "C" {
#endif

	
	__declspec(dllexport) void MyCppFunction(int* result)
	{
		// 修改result的值
		*result = 42;
	}
	
	__declspec(dllexport) const char* GetString() {
		return "Hello World";
	}
	//
	__declspec(dllexport) const int GetStringArray2(String2Array* ss) {
		//std::cout << "Support Values:" << ss->vSupportValue[0] << std::endl;
		//strcpy_s(ss->vSupportValue[0], 16, "Support Value 1");
		//ss->vSupportValue[0] = "sad";
		return 0;
	}

	__declspec(dllexport) const char* GetCharPtr() {
		char* str = new char[64];
		strcpy_s(str, 16, "Support Value 1");
		return str;
	}

	__declspec(dllexport) int GetStringStruct(StringStruct* ss) {
		strncpy_s(ss->vSupportValue, "Support Value 1", 16);

		return 0;
	}
	__declspec(dllexport) void GetEnumValueInfo(EnumValueInfo_C* result)
	{
		// 修改result的值
		strcpy_s(result->sCurValue, "1");
		result->vSupportValueSize = 2;
		//strcpy_s(result->vSupportValue[0], "1");
		//strcpy_s(result->vSupportValue[1], "2");
	}

	__declspec(dllexport) void SendStringArray(char** ppNames, int iNbOfNames)
	{
		// 创建结构体变量并初始化
		for (int iName = 0; iName < iNbOfNames; iName++)
		{
			std::cout << ppNames[iName] << "\n";
			//strcpy_s(ppNames[iName], 16, "Support Value 1");
		}
	}


	__declspec(dllexport) void testEnumValueInfo(EnumValueInfo_C* enumValueInfo)
	{
		// 创建结构体变量并初始化
		strcpy_s(enumValueInfo->sCurValue, "Current Value");
		enumValueInfo->vSupportValueSize = 3;
		//enumValueInfo->vSupportValue[0] = new char[128];
		//enumValueInfo->vSupportValue[1] = new char[128];
		//enumValueInfo->vSupportValue[2] = new char[128];
		strcpy_s(enumValueInfo->vSupportValue[0], 16, "Support Value 1");
		strcpy_s(enumValueInfo->vSupportValue[1], 16, "Support Value 2");
		strcpy_s(enumValueInfo->vSupportValue[2], 16, "Support Value 3");

		// 输出结构体成员的值
		std::cout << "Current Value: " << enumValueInfo->sCurValue << std::endl;
		std::cout << "Support Value Size: " << enumValueInfo->vSupportValueSize << std::endl;
		std::cout << "Support Values:" << std::endl;
		for (int i = 0; i < enumValueInfo->vSupportValueSize; i++)
		{
			std::cout << "- " << enumValueInfo->vSupportValue[i] << std::endl;
		}
	}

	__declspec(dllexport) void GetStringArray(StringArray* stringArray)
	{
		//stringArray->vSupportValue[0] = "132";
		// 创建结构体变量并初始化
		strncpy_s(stringArray->vSupportValue[0], "Support Value 1", 16);
		//strncpy(stringArray->vSupportValue[1], "Support Value 2", 16);
		//strncpy(stringArray->vSupportValue[2], "Support Value 3", 16);

		// 输出结构体成员的值
		std::cout << "Support Values:" << std::endl;
		for (int i = 0; i < 3; i++)
		{
			std::cout << "- " << stringArray->vSupportValue[i] << std::endl;
		}
	}

#ifdef __cplusplus
}
#endif

#endif //PCH_H  
