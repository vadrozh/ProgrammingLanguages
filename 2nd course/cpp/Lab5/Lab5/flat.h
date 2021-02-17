#pragma once
#include "build.h"

class flat :
    public build
{
public:
    flat(
        string       companyName,
        unsigned int floorCount,
        unsigned int buildYear,
        unsigned int apartmentsCount
    ) : build (
        companyName,
        floorCount,
        buildYear
    ) {
        this->apartmentsCount = apartmentsCount;
    }

    void    changeApartmentsCount(unsigned int newApartmentsCount) { apartmentsCount = newApartmentsCount; }
    string  printFlatData        (unsigned int currentYear)        {
        return companyName + " " + to_string(floorCount) + " " + (buildYear > currentYear ? "Не построено" : to_string(buildYear)) + " " + to_string(apartmentsCount);
    }

private:
    unsigned int apartmentsCount;
};

