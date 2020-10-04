#include "sortition.h"

bool sortition::readArrayFromFile(ifstream* file)
{
	if (!fArray.empty())
		fArray.clear();
	arraySize = 0;

	float fBuffer;
	while (!file->eof()) {
		if (!arraySize) {
			*file >> arraySize;
		}
		*file >> fBuffer;
		fArray.push_back(fBuffer);
	}

	if (arraySize)
		return true;
	else
		return false;
}

void sortition::printArray()
{
	if (!fArray.empty() && arraySize) {
		for (size_t i = 0; i < fArray.size(); i++)
			cout << fArray[i] << " ";
		cout << endl << "---------" << endl;
	}
}

void sortition::insertionSort()
{
	if (!fArray.empty() && arraySize)
		for (size_t i = 1; i < arraySize; i++) {
			for (size_t j = i; j > 0 && fArray[j - 1] < fArray[j]; j--) {
				float buffer = fArray[j];
				fArray[j] = fArray[j - 1];
				fArray[j - 1] = buffer;
			}
		}
}

void sortition::exchangeSort()
{
	if (!fArray.empty() && arraySize) {
		float buffer = 0;
		for (size_t i = 1; i < arraySize; ++i)
			for (size_t j = arraySize - 1; j >= i; --j)
				if (fArray[j - 1] > fArray[j]) {
					buffer = fArray[j - 1];
					fArray[j - 1] = fArray[j];
					fArray[j] = buffer;
				}
	}
}
