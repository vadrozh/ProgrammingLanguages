#include "taylor.h"

double taylor::function(double x) { return (exp(x) + log(1 + x)); }

double taylor::derivative(double x, int ord, double h)
{
	if (ord == 1)
		return (function(x + h) - function(x - h)) / (2 * h);
	else if (ord)
		return ((derivative(x + h, ord - 1, h)) - (derivative(x - h, ord - 1, h))) / (2 * h);
}