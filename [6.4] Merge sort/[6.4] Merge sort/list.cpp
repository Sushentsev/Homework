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
	auto list = new List{ 0, nullptr };
	return list;
}

ListElement* createListElement(ListElement *next, const string &name, const string &phone)
{
	auto newListElement = new ListElement{ name, phone, next };
	return newListElement;
}

ListElement* getLastElement(List *list)
{
	auto cursor = list->head;
	while (cursor->next != nullptr)
	{
		cursor = cursor->next;
	}
	return cursor;
}

string getNameFromHead(List *list)
{
	return list->head->name;
}

string getPhoneFromHead(List *list)
{
	return list->head->phone;
}

void removeFromHead(List *&list)
{
	auto oldHead = list->head;
	list->head = list->head->next;
	delete oldHead;
}

void addToHead(List *list, const string &name, const string &phone)
{
	list->head = createListElement(list->head, name, phone);
	++list->length;
}

void addToTale(List *list, const string &name, const string &phone)
{

}

int getSize(List *list)
{
	return list->length;
}

void printList(List *list)
{
	auto cursor = list->head;
	while (cursor != nullptr)
	{
		cout << "���: " << cursor->name << " �������: " << cursor->phone << endl;
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