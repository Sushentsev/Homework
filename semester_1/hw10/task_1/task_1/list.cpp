#include "list.h"
#include <iostream>

using namespace std;

struct ListElement
{
	int value;
	ListElement *next;
};

ListElement *createListElement(ListElement *next, int value)
{
	return new ListElement{ value, next };
}

ListElement *nextElement(ListElement *element)
{
	return element->next;
}

int getValue(ListElement *element)
{
	return element->value;
}

bool isEmpty(ListElement *head)
{
	return head == nullptr;
}

void addToHead(ListElement *&head, int value)
{
	head = createListElement(head, value);
}

bool isContained(ListElement *head, int value)
{
	if (isEmpty(head))
	{
		return false;
	}

	auto cursor = head;
	while (cursor != nullptr)
	{
		if (value == cursor->value)
		{
			return true;
		}
		cursor = cursor->next;
	}
	return false;
}

void printList(ListElement *head)
{
	if (isEmpty(head))
	{
		return;
	}

	auto cursor = head;
	while (cursor != nullptr)
	{
		cout << cursor->value << " ";
		cursor = cursor->next;
	}
}

void removeList(ListElement *&head)
{
	if (isEmpty(head))
	{
		return;
	}
	while (head != nullptr)
	{
		auto temp = head;
		head = head->next;
		delete temp;
	}
}