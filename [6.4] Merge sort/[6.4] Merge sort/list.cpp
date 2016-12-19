#include <iostream>
#include <string>
#include "list.h"

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
	List *list = new List;
	list->length = 0;
	list->head = nullptr;
	return list;
}

ListElement* createListElement(ListElement *next, const string &name, const string &phone)
{
	ListElement *newListElement = new ListElement;
	newListElement->name = name;
	newListElement->phone = phone;
	newListElement->next = next;
	return newListElement;
}

void addToHead(List *list, const string &name, const string &phone)
{
	list->head = createListElement(list->head, name, phone);
	++list->length;
}

bool isEmpty(List *list)
{
	return list->length	 == 0;
}

void removeList(List *list)
{
	while (list->head != nullptr)
	{
		ListElement *toDelete = list->head;
		list->head = list->head->next;
		delete toDelete;
		toDelete = nullptr;
	}

	delete list;
	list = nullptr;
}