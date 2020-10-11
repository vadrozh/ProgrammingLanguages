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

	string printData	  ()							{ return "Company: " + companyName + "Floor count:" + to_string(floorCount) + "Build year:" + to_string(buildYear); }
	void changeCompany	  (string newCompanyName)		{ companyName = newCompanyName; }
	void changeFloorCount (unsigned int newFloorCount)	{ floorCount = newFloorCount; }
	void changeBuildYear  (unsigned int newBuildYear)	{ buildYear = newBuildYear; }

private:
	string		 companyName;
	unsigned int floorCount;
	unsigned int buildYear;
};

