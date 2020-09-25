/*
 * Author: Rozhkov Vadim
 *
 * Group: СБС-901, 3 подгруппа
 *
 * Task, #: 2.29
 *
 * Description: Напечатать таблицу истинности
*/


#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <cmath>

using namespace std;

int calcFunction(int x1, int x2, int x3);

int main()
{
    printf("%5s| %5s| %5s| %5s\n", "x1", "x2", "x3", "y");
    printf("------------\n");
    for(int x1=0; x1<2; x1++) {
        for(int x2=0; x2<2; x2++) {
             for(int x3=0; x3<2; x3++) {
                 const int y = calcFunction(x1,x2,x3);
                 printf("%5s| %5s| %5s| %5s\n", x1 ? "true" : "false", x2 ? "true" : "false", x3 ? "true" : "false", y ? "true" : "false");
             };
        };
    };
}

int calcFunction(int x1, int x2, int x3){
    return ((x1 && x2) || !(x2 || x3));
}
