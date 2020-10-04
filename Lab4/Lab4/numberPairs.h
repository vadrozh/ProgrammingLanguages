#pragma once
class numberPairs
{
public:
	numberPairs(int x, int y) {
		a = x;
		b = y;
	}

	friend numberPairs operator+(const numberPairs& nP1, const numberPairs& nP2) {
		return numberPairs(nP1.a + nP2.a, nP1.b & nP2.b);
	}
	
	int getA() { return a; }
	int getB() { return b; }

private:
	int a = 0, b = 0;

};

