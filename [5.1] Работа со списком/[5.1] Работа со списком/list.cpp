#include <iostream>
#include "list.h"

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

ListElement* createListElement(int value, ListElement *next)
{
	ListElement *newElement = new ListElement;
	newElement->value = value;
	newElement->next = next;
	return newElement;
}

void addElement(List *list, int value)
{
	if (list->size == 0)
	{
		list->head = createListElement(value, nullptr);
		++list->size;
		return;
	}
	ListElement *cursor = list->head;

	if (value < cursor->value)
	{
		list->head = createListElement(value, cursor);
		return;
	}

	while (cursor->next != nullptr && cursor->next->value < value)
	{
		cursor = cursor->next;
	}
	cursor->next = createListElement(value, cursor->next);
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

void printList(List *list)
{
	if (list->size == 0)
	{
		std::cout << "Список пуст!" << std::endl;
		return;
	}

	ListElement *temp = list->head;
	while (temp != nullptr)
	{
		std::cout << temp->value << " ";
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