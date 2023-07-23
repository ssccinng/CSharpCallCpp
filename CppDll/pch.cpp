// pch.cpp: 与预编译标头对应的源文件

#include "pch.h"
#include <iostream>
#include <string>
#include <vector>
#include <cstring>


// 当使用预编译的头时，需要使用此源文件，编译才能成功。



int i = 0;
char c = 'a';
short s = 0;
long long l = 0;
float f = 0.0f;
double d = 0.0;
bool bl = false;



#pragma region 基础数据类型

int GetInt() {
    return i;
}

void SetInt(int new_i) {
    std::cout << "set int: " << new_i << std::endl;
    i = new_i;
}

char GetChar() {
    return c;
}

void SetChar(char new_c) {
    c = new_c;
}

short GetShort() {
    return s;
}

void SetShort(short new_s) {
    s = new_s;
}

long long GetLong() {
    return l;
}

void SetLong(long long new_l) {
    l = new_l;
}

float GetFloat() {
    return f;
}

void SetFloat(float new_f) {
    f = new_f;
}

double GetDouble() {
    return d;
}

void SetDouble(double new_d) {
    d = new_d;
}

bool GetBool() {
    return bl;
}

void SetBool(bool new_bl) {
    bl = new_bl;
}
#pragma endregion


std::string myString;

void SetString(const char* str) {
    myString = str;
}

const char* GetString() {
    return myString.c_str();
}


void ModifyString(char* str, int len) {
    for (int i = 0; i < len; i++) {
        str[i] = std::toupper(str[i]);
    }
}

std::vector<std::string> myStringArray;

void SetStringArray(const char** strArray, int count) {
    myStringArray.clear();
    for (int i = 0; i < count; i++) {
        myStringArray.push_back(strArray[i]);
    }
}

char** GetStringArray(int* count) {
    *count = myStringArray.size();
    char** result = new char*[*count];
    for (int i = 0; i < *count; i++) {
        result[i] = new char[myStringArray[i].size() + 1];
        strcpy_s(result[i], 128, myStringArray[i].c_str());
    }
    return result;
}

std::vector<int> myIntArray;
void SetIntArray(int* intArray, int count) {
    myIntArray.clear();
    for (int i = 0; i < count; i++) {
        myIntArray.push_back(intArray[i]);
    }
}

int* GetIntArray(int* count) {
    *count = myIntArray.size();
    int* result = new int[*count];
    for (int i = 0; i < *count; i++) {
        result[i] = myIntArray[i];
    }
    return result;
}

std::vector<bool> myBoolArray;
void SetBoolArray(bool* boolArray, int count) {
    myBoolArray.clear();
    for (int i = 0; i < count; i++) {
        //std::cout << boolArray[i] << std::endl;
        myBoolArray.push_back(boolArray[i]);
    }
}

void GetBoolArray(bool* boolArray, int count) {
    //boolArray = new bool[count];
    for (int i = 0; i < count; i++) {
        //std::cout << myBoolArray[i] << std::endl;
        boolArray[i] = myBoolArray[i];
    }
}

void ModifyInt(int* i) {
    *i = 114514;
}

void ModifyStruct(TestStruct* s) {
    s->Int1 = 100;
    s->Byte1 = 'A';
    s->Int2 = 200;
    s->Byte2 = 'B';
    s->Byte3 = 'C';
}

void GetStructArray(TestStruct* s, int count) {
    s = new TestStruct[count];
    for (int i = 0; i < count; i++) {
        s[i].Int1 = 100;
        s[i].Byte1 = 'A';
        s[i].Int2 = 200;
        s[i].Byte2 = 'B';
        s[i].Byte3 = 'C';
    }
}