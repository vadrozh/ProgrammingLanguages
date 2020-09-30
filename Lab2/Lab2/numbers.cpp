#include "numbers.h"

void numbers::set(int a, int b) {
	x = a;
	y = b;
}

int numbers::getX() { return x; }

int numbers::getY() { return y; }

int numbers::greatest() { return x > y ? x : y; }

int numbers::squaredSum() { return x*x + y*y; }