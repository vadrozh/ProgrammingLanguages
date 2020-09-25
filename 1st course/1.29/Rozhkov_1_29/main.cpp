/*
 * Author: Rozhkov Vadim
 *
 * Group: СБС-901, 3 подгруппа
 *
 * Task, #: 1.29
 *
 * Description: Даны основания и высота равнобедренной трапеции. Найти ее периметр.
*/


#include <iostream>
#include <cstdio>
#include <cstdlib>
#include <cmath>

using namespace std;

int main()
{
    double a = 0, b = 0, h = 0;
    printf("Count perimeter of isosceles trapezium \n");
    printf("Enter \"a\" and \"b\":\n");
    scanf("%lf %lf", &a, &b);
    printf("Enter \"h\": \n");
    scanf("%lf", &h);
    if ((a <= 0) || (b <= 0) || (h <= 0)) {
        printf("Wrong numbers");
        return 0;
    }
    if (a < b) {
        double temp = a;
        a = b;
        b = temp;
    }
    double p = sqrt((((a-b)/2)*((a-b)/2))+h*h)*2+a+b;
    printf("P = %lf", p);
    return 0;
}
