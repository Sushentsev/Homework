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

List* createList()
{
	List *list = new List;
	list->head = nullptr;
	list->size = 0;
	return list;
}

ListElement* createListElement(ListElement *next, int value)
{
	ListElement *newElement = new ListElement;
	newElement->next = next;
	newElement->value = value;
	return newElement;
}

void addElement(List *list, int value)
{
	if (list->size == 0)
	{
		list->head = createListElement(nullptr, value);
		++list->size;
		return;
	}

	ListElement *cursor = list->head;

	if (value < cursor->value)
	{
		list->head = createListElement(list->head, value);
		return;
	}

	while (cursor->next != nullptr && cursor->next->value < value)
	{
		cursor = cursor->next;
	}
	cursor->next = createListElement(cursor->next, value);
	++list->size;
}

bool removeElement(List *list, int value)
{
	if (list->size == 0)
	{
		return false;
	}

	ListElement *cursor = list->head;

	if (cursor->value == value)
	{
		if (cursor->next == nullptr)
		{
			list->head = nullptr;
		}
		else
		{
			list->head = list->head->next;
		}
		delete cursor;
		cursor = nullptr;
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
		ListElement *toDelete = cursor->next;
		cursor = cursor->next->next;
		delete toDelete;
		--list->size;
		return true;
	}
}

int getValue(List *list, int number)
{
	ListElement *cursor = list->head;
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

	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		cout << temp->value << " ";
		temp = temp->next;
	}
}

void deleteList(List *list)
{
	if (list->size == 0)
	{
		return;
	}

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