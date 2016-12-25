#include "list.h"
#include <iostream>
#include <string>

using namespace std;

struct ListElement
{
	string name;
	string phone;
	ListElement *next;
};

struct List
{
	int length;
	ListElement *head;
};

List* createList()
{
	return new List{ 0, nullptr };
}

ListElement* createListElement(ListElement *next, const string &name, const string &phone)
{
	return new ListElement{ name, phone, next };
}

bool isEmpty(List *list)
{
	return list->length == 0;
}

bool isHeadSmaller(List *list, const short sortType)
{
	if (sizeOfList(list) <= 1)
	{
		return true;
	}

	if (sortType == 0)
	{
		return list->head->name < list->head->next->name;
	}
	else if (sortType == 1)
	{
		return list->head->phone < list->head->next->phone;
	}

	return false;
}

ListElement* getLastElement(List *list)
{
	if (isEmpty(list))
	{
		return nullptr;
	}

	auto cursor = list->head;
	while (cursor->next != nullptr)
	{
		cursor = cursor->next;
	}
	return cursor;
}

string getNameFromHead(List *list)
{
	if (isEmpty(list))
	{
		return "";
	}
	return list->head->name;
}

string getPhoneFromHead(List *list)
{
	if (isEmpty(list))
	{
		return "";
	}
	return list->head->phone;
}

void removeFromHead(List *&list)
{
	if (isEmpty(list))
	{
		return;
	}

	auto oldHead = list->head;
	list->head = list->head->next;
	--list->length;
	delete oldHead;
}

void addToHead(List *list, const string &name, const string &phone)
{
	list->head = createListElement(list->head, name, phone);
	++list->length;
}

void addToTail(List *list, const string &name, const string &phone)
{
	if (isEmpty(list))
	{
		list->head = createListElement(nullptr, name, phone);
		++list->length;
		return;
	}

	auto lastElement = getLastElement(list);
	lastElement->next = createListElement(nullptr, name, phone);
	++list->length;
}

int sizeOfList(List *list)
{
	return list->length;
}

void printList(List *list)
{
	auto cursor = list->head;
	while (cursor != nullptr)
	{
		cout << "Name: " << cursor->name << " Phone: " << cursor->phone << endl;
		cursor = cursor->next;
	}
}

void removeList(List *&list)
{
	while (list->head != nullptr)
	{
		auto toDelete = list->head;
		list->head = list->head->next;
		delete toDelete;
	}
	delete list;
	list = nullptr;
}