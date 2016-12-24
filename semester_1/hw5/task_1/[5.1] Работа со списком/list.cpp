#include <iostream>
#include "list.h"

using namespace std;

struct ListElement
{
	int value;
	ListElement *next;
};

struct List
{
	ListElement *head;
	int size;
};

List *createList()
{
	auto list = new List{ nullptr, 0 };
	return list;
}

ListElement *createListElement(ListElement *next, int value)
{
	auto newElement = new ListElement{ value, next };
	return newElement;
}

bool isEmpty(List *list)
{
	return list->size == 0;
}

void addElement(List *list, int value)
{
	if (isEmpty(list))
	{
		list->head = createListElement(nullptr, value);
		++list->size;
		return;
	}

	auto cursor = list->head;
	if (value < cursor->value)
	{
		list->head = createListElement(list->head, value);
		++list->size;
		return;
	}

	while (cursor->next != nullptr && value > cursor->next->value)
	{
		cursor = cursor->next;
	}
	cursor->next = createListElement(cursor->next, value);
	++list->size;
}

bool removeElement(List *list, int value)
{
	if (isEmpty(list))
	{
		return false;
	}

	auto cursor = list->head;
	if (cursor->value == value && cursor->next == nullptr)
	{
		list->head = nullptr;
		delete cursor;
		--list->size;
		return true;
	}

	if (cursor->value == value)
	{
		list->head = list->head->next;
		delete cursor;
		--list->size;
		return true;
	}

	while (cursor->next != nullptr && cursor->next->value != value)
	{
		cursor = cursor->next;
	}

	if (cursor->next == nullptr)
	{
		return false;
	}
	else
	{
		auto toDelete = cursor->next;
		cursor->next = cursor->next->next;
		delete toDelete;
		--list->size;
		return true;
	}
}

int getValue(List *list, int number)
{
	auto cursor = list->head;
	for (int i = 1; i < number; ++i)
	{
		cursor = cursor->next;
	}
	return cursor->value;
}

void printList(List *list)
{
	if (list->size == 0)
	{
		cout << "Список пуст!" << endl;
		return;
	}

	if (list->size == 1)
	{
		cout << list->head->value << " ";
		return;
	}

	auto temp = list->head;
	while (temp != nullptr)
	{
		cout << temp->value << " ";
		temp = temp->next;
	}
}

void deleteList(List *&list)
{
	if (list->size == 0)
	{
		return;
	}

	while (list->head != nullptr)
	{
		auto toDelete = list->head;
		list->head = list->head->next;
		delete toDelete;
	}
	delete list;
	list = nullptr;
}