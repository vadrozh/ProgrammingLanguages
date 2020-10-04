#pragma once

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

class sortition {
public:
	sortition();
	~sortition();
	void clearMemory();

	bool readArrayFromFile(string filePath);
	void printArray();

private:
	ifstream* file = nullptr;
	vector<float> fArray;
	size_t arraySize = 0;
};

