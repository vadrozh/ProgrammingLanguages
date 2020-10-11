#pragma once
#include <string>

using namespace std;

class build
{
public:
	build(string companyName, unsigned int floorCount, unsigned int buildYear)
	{
		this->companyName = companyName;
		this->floorCount = floorCount;
		this->buildYear = buildYear;
	}

	string printBuildData ()							{ return companyName + " " + to_string(floorCount) + " " + to_string(buildYear); }
	void changeCompany	  (string newCompanyName)		{ companyName = newCompanyName; }
	void changeFloorCount (unsigned int newFloorCount)	{ floorCount = newFloorCount; }
	void changeBuildYear  (unsigned int newBuildYear)	{ buildYear = newBuildYear; }

protected:
	string		 companyName;
	unsigned int floorCount;
	unsigned int buildYear;
};

