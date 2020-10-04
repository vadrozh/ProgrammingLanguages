#include "sortition.h"

sortition::sortition()
{

}

sortition::~sortition()
{
	clearMemory();
}

void sortition::clearMemory()
{
	if (file) {
		file->close();
		delete file;
		file = nullptr;
	}
	arraySize = 0;
}


bool sortition::readArrayFromFile(string filePath)
{
	clearMemory();
	file = new ifstream(filePath);
	if (!file->is_open())
		return false;

	float fBuffer;
	while (!file->eof()) {
		if (!arraySize) {
			*file >> arraySize;
		}
		*file >> fBuffer;
		fArray.push_back(fBuffer);
	}

	return true;
}

void sortition::printArray()
{
	for (size_t i = 0; i < fArray.size(); i++)
		cout << fArray[i]  << " " << endl;
	cout << "Size is " << arraySize << endl;
}
