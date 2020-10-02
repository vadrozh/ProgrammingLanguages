#include "numbers.h"

void numbers::set(int a, int b) {
	x = a;
	y = b;
}

int numbers::getX() { return x; }

int numbers::getY() { return y; }

double numbers::average() { return (x + y) / 2; }

int numbers::odd(){
	int biggest = 0, lowest = 0, oddCount = 0;
	if (x > y) {
		biggest = x;
		lowest = y;
	} else {
		biggest = y;
		lowest = x;
	}
	for (int i = lowest; i <= biggest; i++)
		if (i % 2)
			++oddCount;
	return oddCount;
}