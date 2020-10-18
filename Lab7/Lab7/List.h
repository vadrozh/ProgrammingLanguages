#pragma once
#include <iostream>

using namespace std;

class List
{
private:
	struct Node {
		int a = 0;
		int b = 0;
		Node* next = nullptr;
	};
	Node* start = nullptr;
	Node* actual = nullptr;

public:
	List(int a = 0, int b = 0);
	~List();
	void add(int a, int b);
	void remove();
	void show();
	void change(int a, int b);
	void begin();
	void step();
	void showAll();
	void find(int c = 0);
};

