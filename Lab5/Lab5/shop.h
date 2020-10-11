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
        unsigned int tradingSquare
    ) : build (
        companyName,
        floorCount,
        buildYear
    ) {
        this->tradingSquare = tradingSquare;
    }

    void    changeTradingSquare(unsigned int newTradingSquare)   { tradingSquare = newTradingSquare; }
    string  printShopData      (unsigned int currentYear) {
        return companyName + " " + to_string(floorCount) + " " + (buildYear > currentYear ? to_string(buildYear) : "Not built yet") + " " + to_string(tradingSquare);
    }

private:
    unsigned int tradingSquare;
};

