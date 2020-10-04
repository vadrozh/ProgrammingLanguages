#pragma once

#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

class sortition {
public:
	bool readArrayFromFile(ifstream* file);
	void printArray();

	void insertionSort();
	void exchangeSort();

private:
	vector<float> fArray;
	size_t arraySize = 0;
};

