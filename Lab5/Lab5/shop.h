#pragma once
#include "build.h"
class shop :
    public build
{
public:
    shop(
        string       companyName,
        unsigned int floorCount,
        unsigned int buildYear,
        float        tradingSquare
    ) : build (
        companyName,
        floorCount,
        buildYear
    ) {
        this->tradingSquare = tradingSquare;
    }

private:
    float tradingSquare;
};

