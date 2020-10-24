#include "List.h"

List::List(int a, int b)
{
	Node* initialNode = new Node;
	initialNode->a = a;
	initialNode->b = b;
	this->start = initialNode;
	this->actual = initialNode;
}

List::~List()
{
	actual = start;
	while (actual->next)
		actual = actual->next;
	while (actual != start)
		this->remove();
	delete start;
}

void List::add(int a, int b)
{
	Node* newNode = new Node;
	newNode->a = a;
	newNode->b = b;
	newNode->next = actual->next;
	actual->next = newNode;
}

void List::remove()
{
	Node* removeNode = start;
	while (removeNode->next != actual && actual)
		actual = actual->next;
	if (actual->next)
		start->next = actual->next;
	delete actual;
	actual = start;
}

void List::show() { cout << "(" << actual->a << ", " << actual->b << ")" << endl; }

void List::change(int a, int b)
{
	actual->a = a;
	actual->b = b;
}

void List::begin()
{
	actual = start;
}

void List::step()
{
	if (actual->next)
		actual = actual->next;
}

void List::showAll()
{
	Node* showNode = start;
	while (showNode) {
		if (showNode == actual)
			cout << endl << "[(" << showNode->a << ", " << showNode->b << ")] ";
		else
			cout << endl << '(' << showNode->a << ", " << showNode->b << "); ";
		showNode = showNode->next;
	}
}

void List::find(int c)
{
	Node* showNode = start;
	Node* found = nullptr;
	while (showNode) {
		if ((showNode->a > c) && (showNode->b < c))
			found = showNode;
		showNode = showNode->next;
	}
	if (found)
		actual = found;
	else
		cout << "Таких элементов в списке нет" << endl;
}
